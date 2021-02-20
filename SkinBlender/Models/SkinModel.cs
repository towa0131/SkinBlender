using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkinBlender.Models
{
    class SkinModel
    {
        private string head;

        private string body;

        public string HeadSkinPath
        {
            get { return this.head; }
            set
            {
                this.head = value;

                if (File.Exists(value))
                {
                    this.HeadSkinName = Path.GetFileName(value);
                }
            }
        }

        public string BodySkinPath
        {
            get { return this.body; }
            set
            {
                this.body = value;

                if (File.Exists(value))
                {
                    this.BodySkinName = Path.GetFileName(value);
                }
            }
        }

        public string HeadSkinName { get; set; }

        public string BodySkinName { get; set; }

        public SkinModel()
        {

        }

        public SkinModel(string head, string body)
        {
            this.HeadSkinPath = head;
            this.BodySkinPath = body;
        }
    }
}
