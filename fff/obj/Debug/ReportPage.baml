   M S B A M L   `   `   `  ����>  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  5      /clr-namespace:fff.Propertiesfff.Properties  5          fff.ReportPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:fff     5      *pclr-namespace:fff.Properties     5        N� Title$  Buy4U��5	   	   .��5   
   � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6    �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txbTitlePage��5      $��2��6+   $��0��6?   $��Stretch=�6L   $��24(�6k   $��0,5,0,10q�6z   $��
UltraLight"�6�   $��Trebuchet MS)�6�      fff.Properties.Resources   ReportPageTitle#��Z 6�   
�������
���iii�6   �� 5   
   -   5         ��Name$ 
lstReports��5      $y�	Collapsed=�6'   $��	10,0,10,0q�6>   $��0��6R   $��1��6b   $��20,10,40,40q�6q   
�������
���   �$��0q�6�   $��20(�6�   $��
UltraLight"�6   �� DisplayMemberPath$
 Name��6;  ��6#  ��  � 	Resources 5       �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� Padding J� SnapsToDevicePixels �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName��%   '��       �� 5      " ��6   .�5      �� 	 � ��
 5      �� 5    "   " ��62   .R�5!   &   �� $ Bd��6-   #��z��5"      #��z��5#      #��z��5$      # z��5%       . ._�5'   *   �� #��z��6;   # z 5(   -   #��z��5)   -   5*   '    5+   &   ]� 5-   *    5.   .   �� 5/   2    �@��IsSelectionActive . 50   -   �� 51   2    �@��
IsSelected . 52   -   ./�54   .   �� $ Bd��55   %   	 � ��

 � E��56   %   58   +   5:   #   5<      5=      5>      5@      &   System.Windows.Controls.DataGrid  5B   
   -   5          Name$ dtgCustomReport��5B      $y�	Collapsed=�6,   $��10,10,40,40q�6C   $��1��6Y   $��1��6i   $��17(�6y      
IsReadOnly .    AutoGenerateColumns . ��6�   �� 5E      5G      5I      