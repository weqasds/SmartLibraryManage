﻿using SmartLibraryManage.ViewModels.Pages.UserManage;
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

namespace SmartLibraryManage.Views.Pages.UserManage;

/// <summary>
/// RegisterPage.xaml 的交互逻辑
/// </summary>
public partial class RegisterPage : Page
{
    public RegisterPage(RegisterViewModel viewModel)
    {
        this.DataContext = viewModel;
        InitializeComponent();
    }
}
