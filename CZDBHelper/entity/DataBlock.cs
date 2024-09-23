using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CZDBHelper.entity
{
    /**
   * The DataBlock class represents a data block in the database.
   * It contains a region and a pointer to the data in the database file.
   * The memory structure of a DataBlock object is as follows:
   * +----------------+-----------+
   * | String         | int       |
   * +----------------+-----------+
   * | region         | dataPtr   |
   * +----------------+-----------+
   */

    public class DataBlock
    {
        /**
         * The region of the data block.
         * It is a string representing the geographical region that the data block covers.
         */
        private byte[] region;

        /**
         * The pointer to the data in the database file.
         * It is an integer representing the offset of the data from the start of the database file.
         */
        private int dataPtr;

        public DataBlock(byte[] region, int dataPtr)
        {
            this.region = region;
            this.dataPtr = dataPtr;
        }

        /**
         * Returns the region of this data block.
         *
         * @return the region of this data block
         */

        public String getRegion(byte[] geoMapData, long columnSelection)
        {
            try
            {
                return unpack(geoMapData, columnSelection);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return "null";
            }
        }

        /**
         * Sets the region of this data block to the specified value.
         *
         * @param region the new region
         * @return this data block
         */

        public DataBlock setRegion(byte[] region)
        {
            this.region = region;
            return this;
        }

        /**
         * Returns the data pointer of this data block.
         *
         * @return the data pointer of this data block
         */

        public int getDataPtr()
        {
            return dataPtr;
        }

        /**
         * Sets the data pointer of this data block to the specified value.
         *
         * @param dataPtr the new data pointer
         * @return this data block
         */

        public DataBlock setDataPtr(int dataPtr)
        {
            this.dataPtr = dataPtr;
            return this;
        }

        private String unpack(byte[] geoMapData, long columnSelection)
        {
            long geoPosMixSize = region.First();

            String otherData = Encoding.UTF8.GetString(region.Skip(2).ToArray());

            return otherData;
        }
    }
}