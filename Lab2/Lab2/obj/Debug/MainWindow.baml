   M S B A M L   `   `   `  ����  Lab2    Lab2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Работа с базами данных��5   	   $	��450��6(   $	��800��65   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��10q�69   .+�5      �� $��ID студента��6   �� 5      -   5         ��Name$ studentIDTextBox��5      $��
10,0,286,0q�60   �� 5      $��ФИО��6   �� 5      -   5        $ fullNameTextBox��5      $��
10,0,286,0q�6/   �� 5      $!��Номер телефона��6   �� 5      -   5        $ phoneNumberTextBox��5      $��
10,0,286,0q�62   �� 5      $$��Оценка по Физике��6   �� 5      -   5        $ physicsGradeTextBox��5      $��
10,0,286,0q�63   �� 5      $,��&Оценка по Математике��6   �� 5      -   5        $ mathGradeTextBox��5      $��
10,0,286,0q�60   �� 5      $ 
Horizontal=�6   $��10q�62   .+�5      �� -   5        $��Добавить��5      $	��100��6,   68   �� 5      -   5        $��Изменить��5      $	��100��6,   $��10,0,0,0q�6S   �� 5      -   5        $��Удалить��5      $	��100��6+   $��10,0,0,0q�6R   5      5      &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ studentsDataGrid��5      $��1��6-      AutoGenerateColumns .     CanUserAddRows .  $��10q�6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ ID студента��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6X   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *	StudentID+6X     5!      $ ФИО��6%   $	 * 6O   
 62   �� *
FullName+6O     5"      $! Номер телефона��6%   $	 * 6]   
 6=   �� *PhoneNumber+6]     5#      $% Оценка по Физикеe��6%   $	 * 6a   
 6@   �� *PhysicsGrade+6a     5$      $, &Оценка по Математике��6%   $	 * 6a   
 6C   �� *	MathGrade+6a   5&      5'      5(      