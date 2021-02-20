using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using SkinBlender.Models;
using SkinBlender.Commands;
using SkinBlender.Utils;
using Microsoft.Win32;

namespace SkinBlender.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private SkinModel model;
        private ICommand generate;

        public string HeadSkinPath
        {
            get { return this.model.HeadSkinPath; }
            set
            {
                this.model.HeadSkinPath = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("HeadSkinName");
            }
        }

        public string BodySkinPath
        {
            get { return this.model.BodySkinPath; }
            set
            {
                this.model.BodySkinPath = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("BodySkinName");
            }
        }

        public string HeadSkinName
        {
            get { return this.model.HeadSkinName; }
        }

        public string BodySkinName
        {
            get { return this.model.BodySkinName; }
        }

        public ICommand GenerateCommand => generate;

        public MainWindowViewModel()
        {
            this.model = new SkinModel();
            this.generate = new GenerateCommand(
                () =>
                {
                    Bitmap head = new Bitmap(this.HeadSkinPath);
                    Bitmap body = new Bitmap(this.BodySkinPath);
                    Bitmap output = Blender.Blend(head, body);

                    SaveFileDialog saveDialog = new SaveFileDialog()
                    {
                        DefaultExt = "png",
                        Filter = "Images|*.png;*.bmp;*.jpg"
                    };

                    if (saveDialog.ShowDialog() == true)
                    {
                        ImageFormat format = ImageFormat.Png;
                        string ext = System.IO.Path.GetExtension(saveDialog.FileName);
                        switch (ext)
                        {
                            case ".png":
                                format = ImageFormat.Png;
                                break;
                            case ".jpg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                        }

                        output.Save(saveDialog.FileName, format);
                    }

                },
                () =>
                {
                    if (this.HeadSkinPath != null && this.BodySkinPath != null)
                    {
                        return (File.Exists(this.HeadSkinPath) && File.Exists(this.BodySkinPath));
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
