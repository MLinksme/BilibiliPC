﻿using BiliClient.Utils.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BiliClient.Utils.Net.API;
using System.Threading;

namespace BiliClient.UI
{
    public delegate void tabHandler(VideoInfo info);
    /// <summary>
    /// UserControl_search.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_search : UserControl
    {
        public event tabHandler addTabItem;
        public UserControl_search()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            long id = 0;
            Interact.InteractHandler.URLConvert(textBox_url.Text, ref id);
            Dispatcher.Invoke(() =>
            {
                VideoInfo info = BlblApi.getVideoInfo(id);
                info.aid = id;
                if (addTabItem != null)
                    addTabItem(info);
            });
        }
    }
}