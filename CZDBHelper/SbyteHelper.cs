using System.Linq;

namespace CZDBHelper
{
    public class SbyteHelper
    {
        /// <summary>
        /// 获取 sbyte
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static sbyte[] GetSbytes(byte[] bs, bool reverse = true)
        {
            sbyte[] sbs = new sbyte[bs.Length];
            for (int i = 0; i < bs.Length; i++)
            {
                if (bs[i] > 127)
                    sbs[i] = (sbyte)(bs[i] - 256);
                else
                    sbs[i] = (sbyte)bs[i];
            }
            if (reverse)
            {
                return sbs.Reverse().ToArray();
            }
            else
            {
                return sbs;
            }
        }

        /// <summary>
        /// 获取 Bytes
        /// </summary>
        /// <param name="sbs"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        public static byte[] GetBytes(sbyte[] sbs, bool reverse = true)
        {
            byte[] bs = new byte[sbs.Length];
            for (int i = 0; i < sbs.Length; i++)
            {
                if (sbs[i] < 0)
                    bs[i] = (byte)(sbs[i] + 256);
                else
                    bs[i] = (byte)sbs[i];
            }
            if (reverse)
            {
                return bs.Reverse().ToArray();
            }
            else
            {
                return bs;
            }
        }
    }
}