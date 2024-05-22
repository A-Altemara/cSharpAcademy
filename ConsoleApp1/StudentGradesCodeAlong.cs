namespace ConsoleApp1;

static class StudentGrades
{
    public static void Grades()
    {
        
/* 
 This C# console application is designed to:
    - Use arrays to store student names and assignment scores.
    - Use a `foreach` statement to iterate through the student names as an outer program loop.
    - Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
    - Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
    - Use an algorithm within the outer loop to calculate the average exam score for each student.
    - Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
    - Integrate extra credit scores when calculating the student's final score and letter grade as follows:
        - detects extra credit assignments based on the number of elements in the student's scores array.
        - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
    - use the following report format to report student grades: 
    
    Student         Exam Score      Overall Grade   Extra Credit
   
    Sophia          92.2            95.88   A       92 (3.68 pts)
    Andrew          89.6            91.38   A-      89 (1.78 pts)
    Emma            85.6            90.94   A-      89 (5.34 pts)
    Logan           91.2            93.12   A       96 (1.92 pts)
 */

// Number of current assignments to consider for scoring
int currentAssignments = 5;

string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "George"];
int[] sophiaGrades = [90, 86, 87, 98, 100, 94, 90 ];
int[] andrewGrades = [92, 89, 81, 96, 90, 89 ];
int[] emmaGrades = [ 90, 85, 87, 98, 68, 89, 89, 89 ];
int[] loganGrades = [ 90, 95, 87, 88, 96, 96 ];
// int[] beckyGrades = [92, 91, 90, 91, 92, 92, 92];
// int[] chrisGrades = [84, 86, 88, 90, 92, 94, 96, 98];
// int[] ericGrades = [80, 90, 100, 80, 90, 100, 80, 90];
// int[] georgeGrades = [91, 91, 91, 91, 91, 91, 91 ];

// Dictionary mapping students to their grades
Dictionary<string, int[]> studentsGrades = new()
{
    { studentNames[0], sophiaGrades },
    { studentNames[1], andrewGrades },
    { studentNames[2], emmaGrades },
    { studentNames[3], loganGrades },
    // { studentNames[4], beckyGrades },
    // { studentNames[5], chrisGrades },
    // { studentNames[6], ericGrades },
    // { studentNames[7], georgeGrades }
};

// defining widths for formating the console
int longestName = studentNames.Max(sn=>sn.Length);
int nameWidth = longestName + 6;
int gradeWidth = 15;

Console.WriteLine($"{"Student".PadRight(nameWidth)}{"Exam Score".PadRight(gradeWidth)}{"Overall".PadRight(gradeWidth)}{"Grade".PadRight(gradeWidth)}{"Extra Credit", -10}");
Console.WriteLine(new string('-', nameWidth + 4 * gradeWidth));

// Iterate through each student and their grades calcuating only based on current assignments and adding 10% factor to bonus work
foreach (var studentGrades in studentsGrades)
{
    var studentName = studentGrades.Key;
    var grades = studentGrades.Value;
    decimal scoreSum = 0;
    decimal examSum = 0;
    decimal extraCredit = 0;
    int gradedAssignments = 0;
    foreach (var grade in grades)
    {
        gradedAssignments += 1;
        if (gradedAssignments <= currentAssignments)
        {
            examSum = scoreSum += grade;
        }
        else
        {
            scoreSum += grade / 10.0m;
            extraCredit += grade;
        }
    }
    
    // Calculate scores and print outcome
    var examScore = examSum / currentAssignments;
    var extraCreditScore = extraCredit / (grades.Length - currentAssignments) ;
    var score = scoreSum / currentAssignments;
    var extraCreditPercentage = extraCredit/10 / currentAssignments;
    
    // Print the formatted output for the student's scores
    Console.WriteLine(
        $"{studentName.PadRight(nameWidth)}" +                 // Student name, left-aligned
        $"{examScore,-15:N1}" +                         // Exam score, right-aligned with one decimal place
        $"{score,-15:N1}" +                             // Score, right-aligned with one decimal place
        $"{LetterGrade(score).PadRight(gradeWidth)}" +         // Letter grade, right-aligned
        $"{extraCreditScore,-5}" +                     // Extra credit score, right-aligned
        $" ({extraCreditPercentage:N2} pts)"                       // Extra credit percentage, one decimal place
    );

}

return;

// Function to convert numeric score to letter grade
string LetterGrade(decimal score)
{
    return score switch
    {
        >= 97 => "A+",
        >= 93 => "A",
        >= 90 => "A-",
        >= 87 => "B+",
        >= 83 => "B",
        >= 80 => "B-",
        >= 77 => "C+",
        >= 73 => "C",
        >= 70 => "C-",
        >= 67 => "D+",
        >= 63 => "D",
        >= 60 => "D-",
        _ => "F"
    };
}
    }
}