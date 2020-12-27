using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;

namespace ClientToServerApi
{
    public class Transformation
    {
        public string Extension { get; set; }

        public string FileName { get; set; }

        public byte[] BinaryForm { get; set; }

    }
}
