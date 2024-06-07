using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMotorEncoderApp
{
    public class DataFrame
    {
        //CMD
        readonly byte bSP = 0x01;
        readonly byte bENC = 0x02;
        readonly byte bPID = 0x03;

        readonly byte[] bHEADER = new byte[2] { 0x0A, 0X55 };
        Dictionary<byte, byte> dCMDLen = new Dictionary<byte, byte> {
                                        {0x01, 5},
                                        {0x02, 2},
                                        {0x03, 13},
                                        {0x04, 5}
        };

        //SYNC/ACK
        readonly byte bSYNC = 0x16;
        readonly byte bACK = 0x06;

        public byte Header1 { get; set; }
        public byte Header2 { get; set; }
        public byte Length { get; set; }
        public byte Command { get; set; }
        public byte[] Parameters { get; set; }
        public byte CRC { get; set; }
        public bool IsValid { get; set; }

        public DataFrame()
        {
        }

        public DataFrame(byte[] byteArray, bool isSend = false)
        {
            IsValid = true;
            if (byteArray.Length > 0)
            {
                //Validation byte to byte
                //Header1
                var bytes = byteArray.Take(1).ToArray();
                if (bytes[0] == bHEADER[0])
                    Header1 = bytes[0];
                else
                    IsValid = false;

                //Header2
                bytes = byteArray.Skip(1).Take(1).ToArray();
                if (bytes[0] == bHEADER[1])
                    Header2 = bytes[0];
                else
                    IsValid = false;

                //Command
                bytes = byteArray.Skip(3).Take(1).ToArray();
                if (dCMDLen.ContainsKey(bytes[0]))
                {
                    Command = bytes[0];

                    //Length
                    bytes = byteArray.Skip(2).Take(1).ToArray();
                    if (bytes[0] == dCMDLen[Command])
                        Length = bytes[0];
                    else
                        IsValid = false;
                }
                else
                    IsValid = false;

                //Data
                bytes = byteArray.Skip(4).Take(Length - 1).ToArray();
                if (!bytes.Contains(bACK) && !bytes.Contains(bSYNC))
                    Parameters = bytes;
                else
                    IsValid = false;

                //CRC
                bytes = byteArray.Skip(Length + 3).Take(1).ToArray();
                if (!isSend && bytes[0] == bACK)
                    CRC = bytes[0];
                else if (isSend && bytes[0] == bSYNC)
                    CRC = bytes[0];
                else
                    IsValid = false;
            }
        }

        public byte[] SetPointFrame(float value)
        {
            byte[] length = BitConverter.GetBytes(5);
            byte[] parameters = ByteConverter(value);
            DataFrame frame = new DataFrame
            {
                Header1 = bHEADER[0],
                Header2 = bHEADER[1],
                Length = length[0],
                Command = bSP,
                Parameters = parameters,
                CRC = bSYNC,
            };

            return ToByteArray(frame);
        }

        public byte[] SetModeFrame(int value)
        {
            byte[] length = BitConverter.GetBytes(2);
            byte[] parameters = EnsureBytesLength(BitConverter.GetBytes(value), 1);
            DataFrame frame = new DataFrame
            {
                Header1 = bHEADER[0],
                Header2 = bHEADER[1],
                Length = length[0],
                Command = bENC,
                Parameters = parameters,
                CRC = bSYNC,
            };

            return ToByteArray(frame);
        }

        public byte[] SetPID(float p, float i, float d)
        {
            byte[] length = BitConverter.GetBytes(13);
            byte[] parameters = ByteConverter(p).Concat(ByteConverter(i)).Concat(ByteConverter(d)).ToArray();
            DataFrame frame = new DataFrame
            {
                Header1 = bHEADER[0],
                Header2 = bHEADER[1],
                Length = length[0],
                Command = bPID,
                Parameters = parameters,
                CRC = bSYNC,
            };

            return ToByteArray(frame);
        }

        public byte[] ByteConverter(int value)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            return EnsureBytesLength(byteArray, 4);
        }

        public byte[] ByteConverter(float value)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            return EnsureBytesLength(byteArray, 4);
        }

        private byte[] EnsureBytesLength(byte[] array, int length)
        {
            if (array.Length >= length)
            {
                return array.Take(length).ToArray();
            }
            else
            {
                int paddingCount = length - array.Length;
                byte[] paddedArray = new byte[length];
                Array.Copy(array, 0, paddedArray, paddingCount, array.Length);
                return paddedArray;
            }
        }

        private byte[] ToByteArray(DataFrame dataFrame)
        {
            List<byte[]> byteArrays = new List<byte[]>
            {
                new byte[] { dataFrame.Header1 },
                new byte[] { dataFrame.Header2 },
                new byte[] { dataFrame.Length },
                new byte[] { dataFrame.Command },
                dataFrame.Parameters,
                new byte[] { dataFrame.CRC }
            };

            byte[] result = byteArrays.SelectMany(array => array).ToArray();

            return result;
        }

        public float FloatConverter(byte[] byteArray)
        {
            float result = BitConverter.ToSingle(byteArray, 0);
            return result;
        }

        public int IntConverter(byte[] byteArray)
        {
            int result;
            if (byteArray.Length == 4)
                result = BitConverter.ToInt32(byteArray, 0);
            else
                result = (int)byteArray[0];

            return result;
        }
    }
}
