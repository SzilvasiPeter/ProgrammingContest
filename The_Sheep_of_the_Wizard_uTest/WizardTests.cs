using NUnit.Framework;
using ProgrammingContest;

namespace The_Sheep_of_the_Wizard_uTest
{
    public class WizardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAtLeastEyeMovomentSheep_ThreeSheep_ReturnMinimumEyeMovoment()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 3;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {0, 0},
                {1, 1},
                {10, 0}
            };

            // Act
            int minEyeMovomentIndex = threeSheepWizard.GetAtLeastEyeMovomentSheep();

            // Assert
            Assert.AreEqual(2, minEyeMovomentIndex);
        }

        [Test]
        public void GetSheepsMaximumEyeMovoment_ThreeSheep_ReturnMaxEyeMovoment()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 3;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {0, 0},
                {2, 2},
                {4, 0}
            };

            // Act
            double[] maxAngleOfSheeps = threeSheepWizard.GetSheepsMaximumEyeMovoment();

            // Assert
            Assert.AreEqual(maxAngleOfSheeps[0], 45, 0.001);
            Assert.AreEqual(maxAngleOfSheeps[1], 90, 0.001);
            Assert.AreEqual(maxAngleOfSheeps[2], 45, 0.001);
        }

        [Test]
        public void GetThreeSheepAngle_ThreeSheep_ReturnAngle()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 3;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {0, 0},
                {2, 2},
                {4, 0}
            };

            // Act
            double firstSheepAngle = threeSheepWizard.GetThreeSheepAngle(0, 1, 2);
            double secondSheepAngle = threeSheepWizard.GetThreeSheepAngle(1, 0, 2);
            double thirdSheepAngle = threeSheepWizard.GetThreeSheepAngle(2, 1, 0);

            // Assert
            Assert.AreEqual(firstSheepAngle, 45, 0.001);
            Assert.AreEqual(secondSheepAngle, 90, 0.001);
            Assert.AreEqual(thirdSheepAngle, 45, 0.001);
        }
    }
}