   M S B A M L   `   `   `  ���� K  GApplication SFL1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Application_SFL1Application_SFL1  !    Application_SFL1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Application_SFL1       � Title$  
MainWindow��$	��450��$	��900�� � AllowsTransparency .  � WindowStyle$
 None=����#0B2546.���  � RowDefinitions �� $��25 ���  � ColumnDefinitions �� �� .+�� -   ���#081527$��2�� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� $��Images/stfe.png�� �� BitmapScalingMode$
 Fant=�$��0,0,0,0q��� -   $��0,-1,0,1q�$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#081527��  �@�Cursor$
 Hand��.���� 
�������$��1��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $�	Éolienne���� �� $��Direct��
�������$��2��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $��Créer��
�������$��3��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $��Charger��
�������$��4��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� -   $��Option��
�������$��12(�$��Medium"�$��0,0,10,0q�$��12��$��2��$��25��$	��Top=����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#00A3FF��  �@�Cursor$
 Hand��	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  � �� �#FF4C70����  �� 
TargetType" ��.R��� $��75��$��15�� �� CornerRadius$ 6��#��z��._��� $��Center=�$��Center=��� $��1��$��Center=�$��60q�.+��� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,20q�.+��� $��50��$��50��$��Images/éolienne.png��$
 Fant=��� $��	Éolienne��
�������$��20(�$��Medium"�$��Fonts/#Dosis)�$��10,0,0,0q�$��Center=��� $��	Commander��
�������$��25(�$��Medium"�$��Fonts/#Dosis)��� $��La��
�������$��25(�$��Medium"�$��Fonts/#Dosis)��� $��
Soufflerie��
�������$��25(�$��Medium"�$��Fonts/#Dosis)��� $����Cette application commande la puissance de la soufflerie de manière instantané ou scénarisé. Cette application est détenu et réalisé en partenariat avec le Lycée St Félix ��
�������$��12(�$��Medium"�$��Fonts/#Dosis)�$
��Wrap=�$��0,10,0,0q��� $ 
Horizontal=�$��0,15,0,0q�.+��� -   $��	Commencer��
�������$��14(�$��Medium"�$��0,0,10,0q����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#00A3FF��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �#0091E2���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� $��Créer��
�������$��14(�$��Medium"����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#39385D��  �@�Cursor$
 Hand��	 P� 
 �@J�IsMouseOver . . ���  � �� �#3A3952���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� � $��1��$��2��$��160,-365,-610,85q�z���  �� Angle$ 50Q�.+��� $ 
Horizontal=�$��-350,250,-255,-250q� K� ZIndex$ -1��.+��� .+��� $	��700��$��35�����#FFFFFF$��	150,0,0,0q�$ 20���� $	��700��$��35�����#00A3FF$��0,15,0,0q�$ 20���� $	��700��$��35�����#FFFFFF$��	75,15,0,0q�$ 20��	� $��RadioButton���� .+��� $	��700��$��35�����#FFFFFF$��	150,0,0,0q�$ 20���� $	��700��$��35�����#00A3FF$��0,15,0,0q�$ 20���� $	��700��$��35�����#FFFFFF$��	75,15,0,0q�$ 20��