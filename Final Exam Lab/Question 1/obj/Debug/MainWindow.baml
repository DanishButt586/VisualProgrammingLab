   M S B A M L   `   `   `  ����P  LQuestion_1_Final_Exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Question_1_Final_ExamQuestion_1_Final_Exam  5   	   &     Question_1_Final_Exam.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Question_1_Final_Exam     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ TopicComboBox��5
      $
��Left=�6*   $��301,176,0,204q�6E   $��61��6\   .@�5      �� $��
All Topics��6   �� 5      $
��Math��6   �� 5      $��Science��6   �� 5      $��History��6   5      �� 5   
   -   5        $ DifficultyComboBox��5      $
��Left=�6/   $��375,176,0,204q�6J   $��60��6a   .@�5      �� $��
All Levels��6   �� 5      $
��Easy��6   �� 5      $��Medium��6   �� 5      $
��Hard��6   5      �� 5   
   -   5        $��Add Question��5      $
��Left=�6(   $��6,176,0,202q�6C   $��84��6X   6c   �� 5   
   -   5        $��Edit Question��5      $
��Left=�6)   $��105,176,0,202q�6D   $��84��6[   6f   �� 5   
   -   5        $��Delete Question��5      $
��Left=�6+   $��203,176,0,202q�6F   $��89��6]   6h   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QuestionsDataGrid��5         AutoGenerateColumns .  $��	0,237,0,0q�6J      CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Question Text��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *QuestionText+6]     5      $ Options��6%   $ * 6R    66   �� *	Options+6R     5       $ Correct Answer��6%   $ * 6_    6=   �� *CorrectAnswer+6_     5!      $ Assigned Marks��6%   $ * 6_    6=   �� *AssignedMarks+6_     5"      $ 
Time Limit��6%   $ * 6W    69   �� *	TimeLimit+6W   5$      � 5&   
   -   5        	 �Name$	 LoadingProgressBar��5&      $
��Left=�62   $��
10,520,0,0q�6M   $	��760��6a   $��20��6m   $y�Hidden=�6y   5'      5)      