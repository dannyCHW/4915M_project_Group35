using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4915M_project
{
    class Good
    {
        String length, width, height, weight, description, harmonizedCode, piece, numOfItem, type;

        public Good()
        {

        }

        public Good(String length, String width, String height, String weight, String description, String harmonizedCode, String piece, String numOfItem, String type)
        {
            this.length = length;
            this.width = width;
            this.height = height;
            this.weight = weight;
            this.description = description;
            this.harmonizedCode = harmonizedCode;
            this.piece = piece;
            this.numOfItem = numOfItem;
            this.type = type;
        }

        public void clearGood()
        {
            length = null;
            width = null;
            height = null;
            weight = null;
            description = null;
            harmonizedCode = null;
            piece = null;
            numOfItem = null;
            type = null;
        }

        public String getLength()
        {
            return length;
        }
        public String getWidth()
        {
            return width;
        }
        public String getHeight()
        {
            return height;
        }

        public String getWeight()
        {
            return weight;
        }

        public String getDescription()
        {
            return description;
        }

        public String getHarmonizedCode()
        {
            return harmonizedCode;
        }

        public String getPiece()
        {
            return piece;
        }

        public String getNumOfItem()
        {
            return numOfItem;
        }

        public String getType()
        {
            return type;
        }
    }
}
