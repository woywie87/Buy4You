   M S B A M L   `   `   `  ����>  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  5      /clr-namespace:fff.Propertiesfff.Properties  5          fff.SummaryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:fff     5      *pclr-namespace:fff.Properties     5        N� Title$  SummaryPage��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6    �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txbTitlePage��5      $��2��6*   $��0��6>   $��Stretch=�6K   $��24(�6j   $��0,5,0,10q�6x   $��Trebuchet MS)�6�      fff.Properties.Resources   SummaryPageTitle#��Z 6�   
�������
���iii�6�   �� 5      -   5         ��Name$ 
lstSummary��5      $��1��6+   $��
20,20,0,40q�68   $��0��6L   
������  �� DisplayMemberPath$ Summary��6u   $��0q�6�   $��30(�6�   $��
UltraLight"�6�   
���   �$��Center=�6  ��63  �� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value
	 ���� 67   5       5%      &   System.Windows.Controls.DataGrid  5'   
   -   5        
  Name$
 lstSummDetails��5'   G   $��1��6   $��1��6    $y�	Collapsed=�60   $��50,30,40,40q�6_   $	��Top=�6u      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      
IsReadOnly .    AutoGenerateColumns .  $��16(�6�   $��
UltraLight"�6�   ��6H  ��    Columns 5)      4  .System.Windows.Controls.DataGridTemplateColumn  5*         Event,  &System.Windows.Controls.DataGridColumn   Header# Z 6*      CellTemplate 5+      �� 5,      .R�5-   "   �� $��	10,0,10,0q�6,   $��Normal"�6Z   ��6?   �� *	EventName+6Z   5.      50        51         Summary# Z 6)    52      �� 53      .R�54      �� $��	10,0,10,0q�6(   $��Normal"�6T   $��Center=�6j   ��6;   �� *	Summary+6j   55      57      5:        5<   
   -   5        $
 dtgPivot��5<      $��2��6&   $��1��63   $��50,30,40,40q�6D   $y�	Collapsed=�6Y    . $��14(�6�   ��6�   �� 5@      5C      