   M S B A M L   `   `   `  ����>  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  5      /clr-namespace:fff.Propertiesfff.Properties  5   	       fff.PersonPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:fff     5      *pclr-namespace:fff.Properties     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5        N� Title$  
PersonPage��5
       � 	Resources 5         ButtonControlTemplate �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%Q  &	        �� 5   
   " ��68   .R�5      � .+�5      A� $ 
theEllipse��6k   
������ 
�������$	��Top=�6<   $��40��6T   $��40��6`   6k   �� 5      $��Center=�6#   $��Center=�6>   5       5      P� 5       � �� . . �5      �� $ 
theEllipse��6:    � ��
	 �����5      5      5      .��5      � 
�������
 � RowDefinitions
 5    
   �� 5!      $	��100 �6   �� 5"      $��* �6    � ColumnDefinitions 5%   
   �� 5&      $��* �6    �� 5'      $��* �6   .+�5,   
   �� $��0��6   $��2��6"   .+�5-      �� -   5         ��Name$ txbTitlePage��5-      $��Stretch=�6.   $��24(�6M   $��0,5,0,10q�6\   $��Trebuchet MS)�6n      fff.Properties.Resources   PersonPageTitle#��Z 6�   
�������
���iii�6�   �� 5.       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��	0,10,0,10q�6O   .+�5/      �� -   5         ��Name$ txtPersonName��5/         	PersonNew#��Z 61   $��15,0,0,0q�6[   $��
UltraLight"�6m   $��Stretch=�6�   $	��260��6�   $��34��6�   $��19(�6�   $��Segoe UI Semilight)�6�   6�   �� 50      -   5         ��Name$ btnAddPerson��50      $��Segoe MDL2 Assets)�6J      PersonAddTip � ToolTip# Z 6i   #���   6�   $��10,0,0,0q�6�   .��51      �� $	����6    
���   �$��
UltraLight"�6D   $��Center=�6\   $��Center=�6w   $��25(�6�   $��Segoe MDL2 Assets)�6�   6�   52      53      54      �� 58   
   -   5        $��
lstPersons��58      $��1��6%   $��0��62   $��
20,20,0,40q�6F   
���������6�   ��  � ContextMenu 5:      �� 5;      -   5        $��menuRemovePerson��5;   &    �� 	StaysOpen . 
������� J� BitmapEffect 5<      �� 5=   "   .@�5?      m� -   5        $��removePerson��5?   N      Delete#��Z 6'   6b   5@      ��5D      �� 5E       �� 
TargetType" ��6   .�5F      ��  � ��
	 �����67   �� 5G       � ��$	 0q�6<    �� Triggers 5H      P� 5I       �@��
IsSelected . . �5J   "   ��  � ��
	 ���F�6?   5K      5M      ��5Q      �� 5R      .R�5S      �  �Name$ 	wrapPanel��6$   
�������$
��Auto��6Q   5T      ��5V      �� 5W      .R�5X      �� $ 
Horizontal=�6&   $
��Auto��6?   $	��150��6L   $��70��6[   $��	17,0,0,17q�6g   ��6z   �� *PersonColor+.+�5Y      �� $ 	txbPerson��6(   $��Segoe MDL2 Assets)�6b   $��10,2,0,0q�6�   $��Center=�6�   $��Center=�6�   $��30(�6�   $	����6�   ��6;   �� *PersonColor2+6�   �� 5Z      $��Segoe UI)�6(   $��Center=�6>   $��	10,0,10,0q�6[   $��Center=�6n   $��20(�6�   ��6�   �� *PersonColor2+��6�   �� *Name+5[      5\      5^      &   System.Windows.Controls.DataGrid  5`   
   -   5          Name$ lstPersonDetails��5`      $y�	Collapsed=�6-   $��50,20,40,40q�6F   $��1��6[   $��1��6h   $	��Top=�6y      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      
IsReadOnly .    AutoGenerateColumns .  $��16(�6�   $��
UltraLight"�6  ��6  ��     Columns  5b      4  .System.Windows.Controls.DataGridTemplateColumn  5c      !   Event,  &System.Windows.Controls.DataGridColumn"   Header#" Z! 6)   #   CellTemplate# 5d      �� 5e   "   .R�5f   &   �� $��Normal"�6K   ��60   �� *	EventName+6K   5g   #   5i        5j      $   ReportPersonHeaderOwn#" Z$ 6)   # 5k      �� 5l   "   .R�5m      �� $��Center=�6C   ��6(   �� *
OwnPrice+6C   5n   #   5p        5r      %   ReportPersonHeaderDebtM#" Z% 6)   # 5s      �� 5t   "   .R�5u   &   �� $��Center=�61   ��6N   �� *MPrice+5v   #   5x        5z      &   ReportPersonHeaderDebtF#" Z& 6)   # 5{      �� 5|   "   .R�5}   &   �� $��Center=�61   ��6N   �� *FPrice+5~   #   5�      5�      5�      5�      