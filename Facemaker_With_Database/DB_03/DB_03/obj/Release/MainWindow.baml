   M S B A M L   `   `   `  ���� @  <DB_03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DB_03DB_03      DB_03.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:DB_03       � Title$  
MainWindow��$	��450��$	��800��.��� .+��� -    ��Name$ 
tabControl��.@��� -    ��Name$ t_info��$
��Info��.��� .+��� -    ��Name$ tb_first��$
��Left=�$��23��$��
158,34,0,0q� �� TextWrapping$
 Wrap=�$��
First Name��$	��Top=�$	��120���� -   $ tb_last��$
��Left=�$��23��$��
158,74,0,0q�$
 Wrap=�$��	Last Name��$	��Top=�$	��120���� -   $ tb_city��$
��Left=�$��23��$��158,121,0,0q�$
 Wrap=�$
��City��$	��Top=�$	��120���� -    ��Name$ l_first��$��
First Name��$
��Left=�$��	66,34,0,0q�$	��Top=��� -   $ l_city��$
��City��$
��Left=�$��
66,121,0,0q�$	��Top=�$��66���� -   $ l_last��$��	Last Name��$
��Left=�$��	66,74,0,0q�$	��Top=��� -	    ��Name$ b_Add��$��
Add Person��$
��Left=�$��105,175,0,0q�$	��Top=�$��75��&   System.Windows.Controls.DataGrid  -
     Name$ 
gridPerson��$
��Left=�$��
311,34,0,0q�$	��Top=�$	��237��$	��272���� -   $ b_delete��$��Delete Selected��$
��Left=�$��465,276,0,0q�$	��Top=�$	��107���� -   $ b_update��$��Update Person��$
��Left=�$��201,175,0,0q�$	��Top=�$��95���� -   $ t_occ��$��
Occupation��$��20��$��Bottom=�.��� ���	#FFE5E5E5 � ColumnDefinitions �� .+��� -   	 ��Name$	 
occupation��$
��Left=�$��	93,73,0,0q�$	��Top=�$	��120��.@��� -   
 ��Name$
 cb_occ1��$��IT���� -   $
 cb_occ2��$��Lawyer���� -   $
 cb_occ3��$��Doctor���� -   $	 hobby��$
��Left=�$��
93,203,0,0q�$	��Top=�$	��120��.@��� -   $
 cb_hob1��$��Guitar���� -   $
 cb_hob2��$��Video Games���� -   $
 cb_hob3��$��Sports���� $��
Occupation��$
��Left=�$��
118,34,0,0q�$	��Top=��� $��Hobbies��$
��Left=�$��126,161,0,0q�$	��Top=��� -   $
 t_fm��$��
Face Maker��.��� .+��� -    ��Name$ myCanvas��$
��Left=�$	��317��$��
392,67,0,0q�$	��Top=�$	��382���� 
���   �$��1q�$
��Left=�$	��148��$��8,78,0,0q�$	��Top=�$	��140�� J� RenderTransformOrigin$ 0.501,0.505&��� 
���   �$��1q�$
��Left=�$	��150��$��	8,266,0,0q�$	��Top=�$	��138���� 
���   �$��1q�$
��Left=�$	��148��$��
249,78,0,0q�$	��Top=�$	��138���� 
���   �$��1q�$
��Left=�$	��150��$��249,266,0,0q�$	��Top=�$	��138��]� .+�o� -    o�Name$
 menu�� o� 
IsMainMenu . $	��100��$��20��$��
-600,0,0,0q�$	��Top=� � 	Resources ��%    .@�m� $��MainMenu��.@�m� $
��Face��.@�m� $
��Hair��.@�m� $��Hair 1�� m� Command �� *newHairCMD1+m� $��Hair 2�� �� *newHairCMD2+m� $��Hair 3�� �� *newHairCMD3+m� $
��Eyes��.@�m� $��Eyes 1�� �� *newEyesCMD1+m� $��Eyes 2�� �� *newEyesCMD2+m� $��Eyes 3�� �� *newEyesCMD3+m� $
��Nose��.@�m� $��Nose 1�� �� *newNoseCMD1+m� $��Nose 2�� �� *newNoseCMD2+m� $��Nose 3�� �� *newNoseCMD3+m� $��Mouth��.@�m� $��Mouth 1�� �� *newMouthCMD1+m� $��Mouth 2�� �� *newMouthCMD2+m� $��Mouth 3�� �� *newMouthCMD3+m� $��Random Face�� �� *newRandomCMD+�� $��Hair 1��$
��Left=�$��	52,89,0,0q�$	��Top=�$��30��$��50������ *newHairCMD1+�� $��Hair 2��$
��Left=�$��
52,137,0,0q�$	��Top=�$ 0.927,1.503&�$��30��$��50������ *newHairCMD2+�� $��Hair 3��$
��Left=�$��
52,187,0,0q�$	��Top=�$ 0.927,1.503&�$��30��$��50������ *newHairCMD3+�� $��Eyes 1��$
��Left=�$��
293,89,0,0q�$	��Top=�$��30��$��50������ *newEyesCMD1+�� $��Eyes 2��$
��Left=�$��293,137,0,0q�$	��Top=�$��30��$��50������ *newEyesCMD2+�� $��Eyes 3��$
��Left=�$��293,187,0,0q�$	��Top=�$��30��$��50������ *newEyesCMD3+�� $��Random��$
��Left=�$��170,233,0,0q�$	��Top=�$��30��$��50������ *newRandomCMD+�� $��Mouth 3��$
��Left=�$��293,374,0,0q�$	��Top=�$��30��$��50������ *newMouthCMD3+�� $��Mouth 2��$
��Left=�$��293,326,0,0q�$	��Top=�$��30��$��50������ *newMouthCMD2+�� $��Mouth 1��$
��Left=�$��293,282,0,0q�$	��Top=�$��30��$��50������ *newMouthCMD1+�� $��Nose 3��$
��Left=�$��
52,374,0,0q�$	��Top=�$��30��$��50������ *newNoseCMD3+�� $��Nose 2��$
��Left=�$��
52,326,0,0q�$	��Top=�$��30��$��50������ *newNoseCMD2+�� $��Nose 1��$
��Left=�$��
52,282,0,0q�$	��Top=�$��30��$��50������ *newNoseCMD1+