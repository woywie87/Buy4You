   M S B A M L   `   `   `  ���� >  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  /clr-namespace:fff.Propertiesfff.Properties      fff.EventsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:fff     *pclr-namespace:fff.Properties       N� Title$  
EventsPage�� � 	Resources    ButtonControlTemplate �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  ButtonControlTemplate2��%�  &	        &	 �     �� " ��.R�� .+�A� $ 
theEllipse��
������ 
�������$	��Top=�$��40��$��40���� $��Center=�$��Center=� P�  � �� . . ��� $ 
theEllipse�� � ��
	 ������� " ��.R�� .+�A� $ 
theEllipse��
����İ�
�������$	��Top=�$��40��$��40���� $��Center=�$��Center=� P�  � �� . . ��� $ 
theEllipse�� � ��
	 �����.��� 
�������
 � RowDefinitions
 �� $
��Auto ��� $��* ��� $��40 �.+��� $��0��.+��� -    ��Name$ txbTitlePage��$��Stretch=�$��24(�$��0,5,0,10q�$��Trebuchet MS)�   fff.Properties.Resources   EventPageTitle#��Z 
�������
���iii��� $	��450�� �� Orientation$ 
Horizontal=�$��Center=�$��	0,10,0,10q�.+��� -    ��Name$ txtEventName��   EventNew#��Z $	��260��$��15,0,0,0q�$��Stretch=�$��
UltraLight"�$��34��$��19(�$��Segoe UI Semilight)��� -    ��Name$ btnExpandPerson��   EventExpPersonTip � ToolTip# Z $��Segoe MDL2 Assets)�#���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��25(�$��Segoe MDL2 Assets)��� -   $ btnExpandCalendar��   EventCalendarTip# Z $��Segoe MDL2 Assets)�#���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��25(�$��Segoe MDL2 Assets)��� -   $ btnDefaultCurrency��$ Domyślna waluta��$��16(�$��Normal"�#���  $��10,0,0,0q��� -   $ btnAddEvent��   EventAddTip# Z $��Segoe MDL2 Assets)�#���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��25(�$��Segoe MDL2 Assets)��� -    ��Name$ chkSolo��   EventSoloCheck#��Z $��50,0,0,0q�&   System.Windows.Controls.Calendar  -     Name$ cldEventDate��$	��0.5q�
�������
�������$��Center=�$y�	Collapsed=��� -	    ��Name$ 
lstPersons��$	��0.7q�$��Center=�
�������$��0,0,0,10q� �� SelectionMode$ Multiple=�
�������$y�	Collapsed=�$	��110������ ����  �� 
TargetType" ��.���  � ��
	 ����� �� Triggers P�  �@��
IsSelected . . ���  � ��
	 �  ������ .R��� $ 
Horizontal=����� .R��� $��80��$��70������ *PersonColor+ �� *Name+.+��� $ 	txbPerson��$��Segoe MDL2 Assets)�$��0,5,0,0q�$��Center=�$��Center=�$��50(�$	�������� *PersonColor2+�� $ txbPersonInit��$��Segoe UI Semilight)�$��Center=�$��Center=�$��20(����� *PersonColor2+���� *
Initials+�� -
   $ 	lstEvents��$��1��$ Single=����	#FF213A3A$��20(�$��0q����� *IsSettledColor+����  � ContextMenu �� -   $��menyRemoveEvent�� �� 	StaysOpen . 
������� J� BitmapEffect �� .@�m� -   $��removeEvent��   Delete#��Z m� -   $��settleEvent��$��Rozlicz całe wydarzenie������ " �� P�  �@��
IsSelected . . ���  � ��
	 ��=H���  � ��
	 ���F����� .R��� $ 
Horizontal=�.+��� $ txbEventName��$��20,0,0,0q�$��20(�$��Segoe UI)�$��Center=����� *
FullName+�� {�. $��10,0,0,0q�
�������$��0q����� *pList+���� " ��.���  � ��
	 �������  � ��$	 0q����� .R��� $ 
Horizontal=����� .R��� $��1q�
�������$��30��$��30������ *PersonColor+ �� *Name+._��� $��12(�$��Trebuchet MS)�$��Center=�$��Center=����� *PersonColor2+���� *
Initials+�� $��2��
�������$	��350��$��Right=�$��0,0,25,0q�$��30��$ 
Horizontal=�.+��� -   $ txtSearchEventsBySale��$	��150��$��0,0,10,0q��� -     ��Name$  
cmbFilters��! �� SelectedIndex$! 0��
���OO/�$��1q�$	��150��.@��� .��	Wszystkie�� .��	Grupowe�� .��Solo