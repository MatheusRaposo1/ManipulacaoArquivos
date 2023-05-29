﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LerEscrever
{
    public partial class Form1 : Form
    {
        byte[] buffer;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscreverTxt_Click(object sender, EventArgs e)
        {
            string path = @"c:\curso\file.txt";
            StreamWriter writer = new StreamWriter(path, true, Encoding.Default);

            //string linha = txtConteudo.Text;
            //writer.WriteLine(linha);

            string txt = txtConteudo.Text;
            writer.Write(txt);
            
            //writer.Flush();
            //writer.Dispose();
            writer.Close();
            txtConteudo.Clear();

        }

        private void btnLerTxt_Click(object sender, EventArgs e)
        {
            txtConteudo.Clear();
            string path = @"c:\curso\file.txt";
            StreamReader reader = new StreamReader(path, Encoding.Default);
            //string txt = reader.ReadToEnd();
            //string linha = reader.ReadLine();
            //while (linha != null)
            //{
            //    txtConteudo.Text += linha + "\n";
            //    linha = reader.ReadLine();
            //}
            while (!reader.EndOfStream)
            {
                //char c = (char)reader.Read();
                txtConteudo.Text += (char)reader.Read() + " ";
            }
            reader.Close();
        }

        private void btnLerBinary_Click(object sender, EventArgs e)
        {
            string path = @"c:\curso\zzzz\file.txt";
            string path2 = @"c:\curso\zzzz\audio.mp3";
            string path3 = @"c:\curso\zzzz\video.mp4";
            string path4 = @"c:\curso\zzzz\imagem.png";
            FileStream file = File.OpenRead(path3);
            BinaryReader reader = new BinaryReader(file);

            //while (reader.BaseStream.Position != reader.BaseStream.Length)
            //{
            //   byte b = reader.ReadByte();
            //    txtConteudo.Text += (char)b + " "; 
            //}
            buffer = reader.ReadBytes((int)reader.BaseStream.Length);
            //foreach ( byte b in buffer)
            //{
            //    txtConteudo.Text += (char)b + " ";
            //}
            reader.Close();
            ////buffer = File.ReadAllBytes(path);

        }

        private void btnEscreverBinary_Click(object sender, EventArgs e)
        {
            string path = @"c:\curso\zzzz\fileNovo.txt";
            string path2 = @"c:\curso\zzzz\audioNovo.mp3";
            string path3 = @"c:\curso\zzzz\videoNovo.mp4";
            string path4 = @"c:\curso\zzzz\imagemNovo.png";
            FileStream file = File.OpenWrite(path3);
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(buffer);

            writer.Flush();
            writer.Dispose();
            writer.Close();
        }
    }
}
