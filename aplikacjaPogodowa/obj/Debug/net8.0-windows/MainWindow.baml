   M S B A M L   `   `   `  ����L  HaplikacjaPogodowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:aplikacjaPogodowaaplikacjaPogodowa  5   	   "    aplikacjaPogodowa.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:aplikacjaPogodowa     5   	     � Title$  Pogoda��5   	   $	��600��6   $	��500��6%    � 	Resources 5	      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   Color   
BlurRadius   ShadowDepth   Opacity��%T   &	          5
   
   $ Black��6.   $ 10Q�6<   $ 2Q�6L   $
 0.15Q�6\   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,20q�6"   .+�5      �� $*��$Wybierz miasto lub wpisz jego nazwę��6   $��16(�6C   $
��Bold"�6Q   ���#333$��0,0,0,10q�6u   �� 5      -   5         ��Name$ pickCity��5      $��35��6)   $��14(�65   $��8q�6C   
����������#CCC$��1q�5   =   $��0,0,0,10q�6Q   .@�5      �� $��Warszawa��6   �� 5      $��Prague��6   �� 5      $��London��6   �� 5      $��Katowice��6   �� 5      $��Gliwice��6   �� 5       $��	Barcelona��6   �� 5!      $��Budapest��6   �� 5"      $��Paris��6   �� 5#      $��Moscow��6   �� 5$      $��Madrid��6   �� 5%      $��Porto��6   �� 5&      $��
Washington��6   �� 5'      $��Catania��6   �� 5(      $��Palermo��6   �� 5)      $��Wieden��6   �� 5*      $
��Oslo��6   �� 5+      $��Helsinki��6   5,      �� 5/      -   5         ��Name$ cityTextBox��5/      $��35��6+   $��14(�67   $��8q�6E   
����������#CCC$��1q�50   <   $��0,0,0,10q�6P   �� 53      -   5        	 ��Name$	 SearchButton��53      $��🌤️ Pobierz pogodę��6+   $��40��6H   $��14(�6T   ���#4A90E2
�������$��0q�54   =   
 � Cursor$

 Hand��6Q   $��0,0,0,10q�55      ��56      �� 57       �� 
TargetType" ��6&   .R�58      �� #��z��6!    �� CornerRadius$ 6��59   !   ._�5:      �� $��Center=�6/   $��Center=�6L   5;      5<      5>      5?      �� 5A   
   $��1��6   $��Center=�6"   $��0,0,0,20q�6?   .+�5B      �� 
�������$ 12��6(    �� Padding$ 10q�6:   $	��100��6G   $	��100��6S    J� Effect# [  5C      ._�5D      �� -   5         ��Name$ 
fotoPogoda��5D      $��Uniform=�6,   5E      5F      �� 5H   
   $��2��6   
�������$ 20q�61   $ 12��6>   # [  5I      ._�5J      �� -   5         ��Name$ wyswietlacz��5J      $��30(�6.   $�� ��6<    �� TextAlignment$ Center=�6D   5K      5L      5N      