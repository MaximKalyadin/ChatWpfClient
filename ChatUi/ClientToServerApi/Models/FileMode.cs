using System;
using System.Collections.Generic;
using System.Text;

namespace ClientToServerApi.Models
{
    public class FileModel
    {
        public string Extension { get; set; }

        public string FileName { get; set; }

        public byte[] BinaryForm { get; set; }
    }
}
