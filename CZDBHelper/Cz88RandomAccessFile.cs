using System;
using System.IO;

namespace CZDBHelper
{
    public class Cz88RandomAccessFile : FileStream
    {
        private int offset;

        public Cz88RandomAccessFile(String name, FileMode mode, int offset) : base(name, mode)
        {
            this.offset = offset;
        }

        /**
         * Sets the file-pointer offset, measured from the beginning of this file, at which the next read or write occurs.
         * The offset may be set beyond the end of the file. Setting the offset beyond the end of the file does not change the file length.
         * The file length will change only by writing after the offset has been set beyond the end of the file.
         *
         * @param pos the offset position, measured in bytes from the beginning of the file, at which to set the file pointer
         * @throws IOException if pos is less than 0 or if an I/O error occurs
         */

        public void seek(long pos)
        {
            base.Seek(pos + offset, SeekOrigin.Begin);
        }

        public long length()
        {
            return base.Length - offset;
        }
    }
}