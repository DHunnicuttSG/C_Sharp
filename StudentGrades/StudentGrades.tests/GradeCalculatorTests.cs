namespace StudentGrades.tests
{
    public class Tests
    {
        private GradeCalculator _gradeCalculator { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            _gradeCalculator = new GradeCalculator();
        }

        [Test]
        public void GetGradeByPercentage()
        {
            //Assign
            var percentage = 99;

            //Act
            var grade = _gradeCalculator.GetGradeByPercentage(percentage);

            //Assert

            Assert.That(grade, Is.EqualTo("A"));
        }
    }
}