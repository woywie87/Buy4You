   M S B A M L   `   `   `  ���� >  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  /clr-namespace:fff.Propertiesfff.Properties      fff.SummaryPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     #localclr-namespace:fff     *pclr-namespace:fff.Properties       N� Title$  SummaryPage��.��� 
������� � RowDefinitions �� $
��Auto ��� $��5* ��� $��5* � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ txbTitlePage��$��2��$��0��$��Stretch=�$��24(�$��0,5,0,10q�$��Trebuchet MS)�   fff.Properties.Resources   SummaryPageTitle#��Z 
�������
���iii��� -    ��Name$ 
lstSummary��$��1��$��
20,20,0,40q�$��0��
������  �� DisplayMemberPath$ Summary��$��0q�$��30(�$��
UltraLight"�
���   �$��Center=����� ����  �� 
TargetType" ��.���  �� Property � ��	 �� Value
	 ���� &   System.Windows.Controls.DataGrid  -   
  Name$
 lstSummDetails��$��1��$��1��$y�	Collapsed=�$��50,30,40,40q�$	��Top=�   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   
IsReadOnly .    AutoGenerateColumns .  $��16(�$��
UltraLight"�����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     Event,  &System.Windows.Controls.DataGridColumn   Header# Z    CellTemplate �� .R��� $��	10,0,10,0q�$��Normal"����� *	EventName+     Summary# Z  �� .R��� $��	10,0,10,0q�$��Normal"�$��Center=����� *	Summary+  -   $
 dtgPivot��$��2��$��1��$��50,30,40,40q�$y�	Collapsed=� . $��14(����� 