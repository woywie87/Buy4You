   M S B A M L   `   `   `  ���� >  :fff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ffffff  /clr-namespace:fff.Propertiesfff.Properties      fff.SalePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     #localclr-namespace:fff     *pclr-namespace:fff.Properties       N� Title$  SalePage�� � 	Resources    ButtonControlTemplate2 �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  ButtonControlTemplate
 A�Name  ButtonControlTemplate3��%[  &	        &	 �     &	 }    �� " ��.R�� .+��� $ theRect��
������ 
�������$��Center=�$��25��$��25���� $��Center=�$��Center=� P�  � �� . . ��� $ theRect�� � ��
	 ������� " ��.R�� .+�A� $
 
theEllipse��
������ 
�������$	��Top=�$��35��$��35���� $��Center=�$��Center=� P�  � �� . . ��� $ 
theEllipse�� � ��
	 ������� " ��.R�� .+�A� $
 
theEllipse��
����İ�
�������$	��Top=�$��35��$��35���� $��Center=�$��Center=� P�  � �� . . ��� $ 
theEllipse�� � ��
	 �����.��� 
������� � RowDefinitions �� $
��Auto ��� $��* ��� $��40 �.+��� $��0��.+��� $��0,5,0,10q�$��Stretch=�
���iii�.+��� -    ��Name$ txbEventTitle��$��24(�$��20,0,0,0q�$��Trebuchet MS)�
����������� ��  �� Orientation$ 
Horizontal=�$��Center=�$��0,5,0,0q�.+��� .+��� -   $ txbPayer��   fff.Properties.Resources   SalePayerToolTip#��Z $��0,0,0,5q�$��Segoe UI Semilight)����	#FF213A3A$��16(�$	��150���� -    ��Name$ cmbPayer��$��34�� �� SelectedIndex$ 0��$��19(�$��Segoe UI Semilight)�$	��150�� �� DisplayMemberPath$
 Name������ �� $��40,0,0,0q�.+��� -   $ 	txbBuyers��   SaleBuyerToolTip#��Z $
��Left=�$��0,0,0,5q�$��Segoe UI Semilight)����	#FF213A3A$��15(��� $ 
Horizontal=�.+��� -    ��Name$ 	lstBuyers��$��Bottom=� �� SelectionMode$ Multiple=�$��1q�
�������
�������$��35������ ���� .R��� $ 
Horizontal=����� .R��� 
�������$	��0.5q�$��25��$��25������ *PersonColor+ � ToolTip �� *Name+._��� $��Center=�$��Center=����� *PersonColor2+���� *
Initials+�� -    ��Name$ chkAll��$��Center=�$��10,0,0,0q�
������� � LayoutTransform ��  �� ScaleX$	 1.5Q� �� ScaleY$	 1.5Q��� $��Center=�$��	13,10,0,0q�$ 
Horizontal=�.+��� -    ��Name$ txtDescription��$��34��$	��180��$��19(�$��Segoe UI Semilight)�   SaleNewSale#��Z $��10,0,0,0q��� -   $ txtPrice��   SalePriceTip# Z $��50��$��34��$��19(�$��Segoe UI Semilight)�$��10,0,0,0q��� -	    ��Name$ btnExpandCalc��   SaleExpCalcTip# Z $��35��$��35��#���  $��10,0,0,0q�.���� $	����
���   �$��17(�$��
UltraLight"�$��Segoe MDL2 Assets)��� -
   $ btnSaleCuurency��$ Waluta��$��35��$��35��$��Normal"�#���  $��10,0,0,0q��� -   $ 
btnAddSale��   
SaleAddTip# Z $��35��$��35��$��Segoe MDL2 Assets)�#���  $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��17(�$��Segoe MDL2 Assets)��� $ 
Horizontal=��� -     ��Name$  stkCalc��$��5,10,0,0q�$��Center=�$y�	Collapsed=�$ 
Horizontal=�.+��� -   $ txtCalc��$	��250��$��10,0,0,0q�$��19(��� -   $ btnMoveCalcValue��!   CalcSum# Z! $��25��$��25��$��Segoe MDL2 Assets)�#���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��15(�$��Segoe MDL2 Assets)��� -   $ btnClearCalc��"   	CalcClear# Z" $��25��$��25��$��Segoe MDL2 Assets)�#���   $��10,0,0,0q�.���� $	����
���   �$��
UltraLight"�$��15(�$��Segoe MDL2 Assets)��� -   $ lstSaleDetails��$��0,10,0,0q�$��1��
�������$��0q����� # � ContextMenu# �� -   $��menuRemoveSale��$ �� 	StaysOpen$ . 
�������% J� BitmapEffect% �� .@�m� -   $��
removeSale��&   Delete#��Z& m� -   $��
settleSale��'   Settle#��Z' ���� ( �� 
TargetType"( ��.���  � ��$	 34����  � ��$	 Stretch=����� .R�� ) �Name$) grdSaleDetails��$
��Auto������ *IsSettledColor+* � ColumnDefinitions* �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1q�
�������$��0��$��20,3,0,0q�$	��Top=�$��25��$��25�� �� *Payers.Name+���� *Payers.PersonColor+._��� $��Center=�$��Segoe UI Semilight)�$��Center=�$��0,0,0,0q�$��15(����� *Payers.PersonColor2+���� *Payers.Initials+�� $	��Top=�$��10,5,0,0q�$��1��$��15(�$��Segoe UI Semilight)����� *Description+�� $	��Top=�$��10,5,0,0q�$��2��$��15(�$��Segoe UI Semilight)����� *	PriceConv+�� $ lstBuyPrices��$��0q�+ �� PanningMode$+ HorizontalOnly=�$��Hidden=�$��3��$��60��$
��Auto��$	��Top=�{�. 
�������$��10,0,0,0q����� *bList+���� "( ��.���  � ��
	 ��������� .R��� $ 
Horizontal=����� .R��� $  stkBuyPrice��
�������.+��� 
�������$��1q�$��20��$��25������ *Buyers.PersonColor+ �� *Buyers.Name+._��� $��12(�$��Trebuchet MS)�$��Center=�$��Center=����� *Buyers.PersonColor2+���� *Buyers.Initials+�� $��0,10,0,0q�
�������
�������$��1q�$��20��$��25��._��� $��12(�$��Trebuchet MS)�$��Center=�$��Center=�
����������� *Price+�� $	��Top=�$��10,5,0,0q�$��4��$��15(�$��Segoe UI Semilight)����� *BasePriceConv+�� -   $ 
txbSumSale��$��2��$��20��$��10,10,10,10q�$��17(����� 