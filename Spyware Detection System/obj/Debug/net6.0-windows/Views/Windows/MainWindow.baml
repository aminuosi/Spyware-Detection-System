   M S B A M L   `   `   `  ����S  OSpyware Detection System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Spyware_Detection_System.Views.Windows&Spyware_Detection_System.Views.Windows  5      [2clr-namespace:Spyware_Detection_System.Views.Pages$Spyware_Detection_System.Views.Pages  5      7    1Spyware_Detection_System.Views.Windows.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:Spyware_Detection_System.Views.Windows     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Dpages2clr-namespace:Spyware_Detection_System.Views.Pages     5      A =Wpf.Ui, Version=2.0.3.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	      $
��1100��5      $	��650��5         TextFillColorPrimaryBrush#���   5        Wpf.Ui.Controls.UiWindow!    ExtendsContentIntoTitleBar$
  True��5         WindowBackdropType$
 Mica=�5         WindowCornerPreference$ Round=�5       � WindowStartupLocation$ CenterScreen=�5       � Title 5
      �� *ViewModel.ApplicationTitle+ �� Mode$ OneWay=�.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ RootMainGrid��5      $��1��5      $��0q�5       � ColumnDefinitions 5       �� 5!      $
��Auto �6#   �� 5"      $��* �6#   .+�5%      � $��0��6   $��
18,0,18,18q�6#    5&      �� 5'      $��67 �6$   �� 5(      $
��Auto �6$   �� 5)      $��* �6$   .+�5,      �� $��0��6   $
��0,12q�6*   .+�5-      �� $��16(�6    $��Spyware_Detection_System��6.   �� 5.      $��10(�5/        TextFillColorTertiaryBrush#���  50      $��Fluent design��51      52      $  Wpf.Ui.Controls.AutoSuggestBox  54      $��1��6$   $��0,0,0,12q�61   &   Wpf.Ui.Controls.NavigationFluent  57      -   5        	  Name$	 RootNavigation��58      $��2��59      /  )Wpf.Ui.Controls.Navigation.NavigationBase
   Footer
 5:      �� *ViewModel.NavigationFooter+$ TwoWay=�   Frame 5;      ��  �� ElementName$ 	RootFrame��$ OneWay=�   Items 5<      �� *ViewModel.NavigationItems+$ TwoWay=�5=      �� 5@      $��1��6    �� CornerRadius$ 8,0,0,0��6%   ._�5A      �  5B      �� 5C      $
��Auto �6(   �� 5D      $��* �6(   .+�5F       � -   5          �Name$ 	RootFrame��5G      $��1��5H      $��0q�5I         Wpf.Ui.Controls.Breadcrumb  5J      $��0��5K      $��0,0,0,12q�5L      $
��Left=�5M      $	��Top=�5N      $��24(�5O         
Navigation 5P      �� $ RootNavigation��$ OneWay=�5Q      5R      5S        Wpf.Ui.Controls.TitleBar  5X   
   $��0��5Z         Icon$; 5pack://application:,,,/Assets/applicationIcon-256.png��5[         UseSnapLayout$
 True��5\         Title 5Y      �� *ViewModel.ApplicationTitle+$ OneWay=�   Tray 5]         Wpf.Ui.Controls.NotifyIcon  5^         FocusOnLeftClick$
 True��5_         Icon$; 5pack://application:,,,/Assets/applicationIcon-256.png��5`         MenuOnRightClick$
 True��5a         TooltipText$ Spyware_Detection_System��5b         Menu 5c      �� 5d      .@�5e      m� $
��Home��6'   
 � Tag$
 home��65   5f      5h      5j      5k      5l      