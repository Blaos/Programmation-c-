   M S B A M L   `   `   `  ���� K  GApplication SFL1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Application_SFL1Application_SFL1  "    Application_SFL1.Instantané   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Application_SFL1       � Title$  Window1��$	��450��$	��900�� � AllowsTransparency .  � WindowStyle$
 None=����#0B2546.���  � RowDefinitions �� $��25 ���  � ColumnDefinitions �� $	��450 ��� .+�� -   ���#081527$��2�� �� �� �� �� �� �� �� �� �� �� �� �� �� �� .+��� -   $��0,-1,0,1q�$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#081527��  �@�Cursor$
 Hand��.���� -   $��	Éolienne��
�������$��1��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $��Direct��
�������$��2��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $��Créer��
�������$��3��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� $��Charger��
�������$��4��$��Center=�$��Center=�$��Fonts/#Dosis)�$��Medium"��� -   $��Option��
�������$��12(�$��Medium"�$��0,0,10,0q�$��12��$��2��$��25��$	��Top=����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#00A3FF��  �@�Cursor$
 Hand�� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 . . ���  � �� �#FF4C70����  �� 
TargetType" ��.R��� $��75��$��15�� �� CornerRadius$ 6��#��z��._��� $��Center=�$��Center=��� $��1��$��Stretch=�$��-250,5,7,10q�$��1�� � Cursor$
 Hand��.+��� .+���  �� Orientation$ 
Horizontal=�$��	0,50,0,20q�.+��� $��50��$��50��$��Images/éolienne.png�� �� BitmapScalingMode$
 Fant=��� $��	Éolienne��
�������$��20(�$��Medium"�$��Fonts/#Dosis)�$��10,0,0,0q�$��Center=��� $��Mode Instantané :��
�������$��25(�$��Medium"�$��Fonts/#Dosis)�$��0,0,0,0q��� $G��ALe mode instantané, permet de commander la soufflerie en direct.��
�������$��12(�$��Medium"�$��Fonts/#Dosis)�$
��Wrap=�$��0,10,0,0q��� $ 
Horizontal=�$��0,15,0,0q�.+��� $��55��$��60��$��Images/Wind.png��$
 Fant=�$��-5,10,-28,0q��� $��40��$��40��$��Images/Power.png��$
 Fant=�$��-25,90,-28,0q��� $��30��$��30��$��Images/Time.png��$
 Fant=�$��-13,170,20,0q��� $��Force du vent :��
�������$��20(�$��Medium"�$��Fonts/#Dosis)�$��-10,100,0,0q�$	��Top=��� $��	Energie :��
�������$��20(�$��Medium"�$��Fonts/#Dosis)�$��-170,140,0,0q�$	��Top=�$��96���� $��Temps :��
�������$��20(�$��Medium"�$��Fonts/#Dosis)�$��-170,180,0,0q�$	��Top=�$��96���� -   $��	Démarrer��
�������$��12(�$��Medium"�$��280,190,0,0q����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#00A3FF��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#FF4C70���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=��� $��Arrêt��
�������$��12(�$��Medium"�$��
20,190,0,0q����� " ��.���  � ��$ Fonts/#Dosis)���  � �� �#39385D��  �@�Cursor$
 Hand�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#3A3952���� " ��.R��� $	��100��$��25��$ 12��#��z��._��� $��Center=�$��Center=�� $��1��$��2��$��268,-474,-718,194q�z���  �� Angle$ 90Q�.+��� $ 
Horizontal=�$��-251,358,-354,-358q� K� ZIndex$ -1��.+��� .+��� $	��600��$��35�����#FFFFFF$��900,190,0,0q�$ 20���� $	��700��$��35�����#00A3FF$��
800,15,0,0q�$ 20���� $	��700��$��35�����#FFFFFF$��
900,15,0,0q�$ 20���� $
��Left=�$��612,359,0,0q�$	��Top=�$��26��$	��266�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� $	 -90Q�T� 