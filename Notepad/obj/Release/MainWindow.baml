   M S B A M L   `   `   `  ���� B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad      Notepad.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Notepad       � Title$  
MainWindow��$��381.564��$	��525�� � DataContext �� *Main+   Locator �� Source# [  .��� .+��� -    ��Name$ textBox1��$
��Left=�$	��180��$��
71,129,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��436������ *SelectedNote.Content+�� -   $ textBox��$
��Left=�$��23��$��	71,71,0,0q�$
 Wrap=�$	��Top=�$	��120��{�.  ���� *SelectedNote.ID+�� -   $ textBox2��$
��Left=�$��23��$��
71,100,0,0q�$
 Wrap=�$	��Top=�$	��120������ *SelectedNote.Title+�� -    ��Name$ label��$	��ID:��$
��Left=�$��	46,71,0,0q�$	��Top=�$��23���� -   $ label1��$��Title:��$
��Left=�$��
36,100,0,0q�$	��Top=�$��23���� -   $ label2��$��Content:��$
��Left=�$��
16,124,0,0q�$	��Top=�$��28���� -    ��Name$ comboBox��$
��Left=�$��	71,44,0,0q�$	��Top=�$	��120�� �� DisplayMemberPath$ Title������  �� Path$ Notes�	 �� SelectedItem	 �� $ SelectedNote�
 �� Mode$
 TwoWay=��� -   $ label3��$��Notes:��$
��Left=�$��	27,40,0,0q�$	��Top=��� -	    ��Name$ 
SaveButton��$��	Save Note��$
��Left=�$��
71,314,0,0q�$	��Top=�$��75���� -
   $ AddNoteButton��$��Add Note��$
��Left=�$��	71,14,0,0q�$	��Top=�$��75��