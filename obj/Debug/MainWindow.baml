   M S B A M L   `   `   `  ����I  EWealthProphet2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WealthProphet2WealthProphet2  5   	   r nSystem.Windows.Forms.DataVisualization.MSChartExtension, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null�~clr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization.MSChartExtension/System.Windows.Forms.DataVisualization.Charting 5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	       WealthProphet2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WealthProphet2     5   	   �cht~clr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization.MSChartExtension     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$  
MainWindow��5
   	   $	��786��6   $
��1777��6)    J� OpacityMask
 �   �.��5      � $��
0,0,-8,-21q�6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      .+�5   
   �� -   5         ��Name$
 But1��5      $��Button 1��6   $
��Left=�62   $��1664.5,686.665,0,0q�6M   $	��Top=�6i   $��75��6�    �� 	ClickMode$ Press=�6�   $��19.96��6�   $��1��6�   �� 5   
   -   5        $ button2��5      $��Button 2��6"   $
��Left=�65   $��24.835��6P   $��1664.5,711.625,0,0q�6`   $	��Top=�6|   $��75��6�   $��1��6�    J� RenderTransformOrigin$ 1.773,0.617&�6�   9� 5   
   $��View Raw Data��6   $
��Left=�6*   $��701.5��6E   $��2,10,0,0q�6T   $	��Top=�6f   $	��359��6~   $��1��6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ MyTable��5      $
��Left=�6(   $	��492��6C   $	��Top=�6P   $	��347��6h      MinColumnWidth$ 60Q�6t   5      �� 5   
   -   5         ��Name$ Stack1��5      $��1��6%   $
��Left=�69   $��736.46��6T   $��	941,0,0,0q�6d   $	��Top=�6w   $��798.5��6�   >  8System.Windows.Controls.DataVisualization.Charting.Chart  5   
   -   5        	  Name$	 Chart1��5       $��2��60   $
��Left=�6D   $	��504��6_   $��1118,77,0,0q�6l   $	��Top=�6�   $��621.5��6�   
   Series.
 5      B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value��6@      IndependentValuePath$	 Key��6[   ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Pet Preference��6v      IsSelectionEnabled . $
��Left=�6�   $	��432��6�   $��0q�6�   $	��Top=�6�   $	��516��6�      ItemsSource 6(   �� 6�   5      5      5      