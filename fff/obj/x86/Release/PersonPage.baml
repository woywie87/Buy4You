   M S B A M L   `   `   `  ���� >  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  /clr-namespace:fff.Propertiesfff.Properties      fff.PersonPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     #localclr-namespace:fff     *pclr-namespace:fff.Properties     U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls    N� Title$  
PersonPage�� � 	Resources    ButtonControlTemplate �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%�   &	        �� " ��.R�� .+�A� $ 
theEllipse��
������ 
�������$	��Top=�$��40��$��40���� $��Center=�$��Center=� P�  � �� . . ��� $ 
theEllipse�� � ��
	 �����.��� 
�������
 � RowDefinitions
 �� $	��100 ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��2��.+��� -    ��Name$ txbTitlePage��$��Stretch=�$��24(�$��0,5,0,10q�$��Trebuchet MS)�   fff.Properties.Resources   PersonPageTitle#��Z 
�������
���iii���  �� Orientation$ 
Horizontal=�$��Center=�$��	0,10,0,10q�.+��� -    ��Name$ txtPersonName��   	PersonNew#��Z $��15,0,0,0q�$��
UltraLight"�$��Stretch=�$	��260��$��34��$��19(�$��Segoe UI Semilight)��� -    ��Name$ btnAddPerson��$��Segoe MDL2 Assets)�   PersonAddTip � ToolTip# Z #���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��Center=�$��Center=�$��25(�$��Segoe MDL2 Assets)��� -   $��
lstPersons��$��1��$��0��$��
20,20,0,40q�
�����������  � ContextMenu �� -   $��menuRemovePerson�� �� 	StaysOpen . 
������� J� BitmapEffect �� .@�m� -   $��removePerson��   Delete#��Z ����  �� 
TargetType" ��.���  � ��
	 �������  � ��$	 0q� �� Triggers P�  �@��
IsSelected . . ���  � ��
	 ���F����� .R��  �Name$ 	wrapPanel��
�������$
��Auto������ .R��� $ 
Horizontal=�$
��Auto��$	��150��$��70��$��	17,0,0,17q����� *PersonColor+.+��� $ 	txbPerson��$��Segoe MDL2 Assets)�$��10,2,0,0q�$��Center=�$��Center=�$��30(�$	�������� *PersonColor2+�� $��Segoe UI)�$��Center=�$��	10,0,10,0q�$��Center=�$��20(����� *PersonColor2+���� *Name+&   System.Windows.Controls.DataGrid  -     Name$ lstPersonDetails��$y�	Collapsed=�$��50,20,40,40q�$��1��$��1��$	��Top=�   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   
IsReadOnly .    AutoGenerateColumns .  $��16(�$��
UltraLight"�����     Columns  4  .System.Windows.Controls.DataGridTemplateColumn  !   Event,  &System.Windows.Controls.DataGridColumn"   Header#" Z! #   CellTemplate# �� .R��� $��Normal"����� *	EventName+  $   ReportPersonHeaderOwn#" Z$ # �� .R��� $��Center=����� *
OwnPrice+  %   ReportPersonHeaderDebtM#" Z% # �� .R��� $��Center=����� *MPrice+  &   ReportPersonHeaderDebtF#" Z& # �� .R��� $��Center=����� *FPrice+