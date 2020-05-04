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

        [Test]
        public void GetSheepsMaximumEyeMovoment_FourSheep_OneSheep180Angle()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 4;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {0, 0},
                {2, 2},
                {1, 1},
                {4, 0}
            };

            // Act
            double[] maxAngleOfSheeps = threeSheepWizard.GetSheepsMaximumEyeMovoment();

            // Assert
            Assert.AreEqual(maxAngleOfSheeps[0], 45, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[1], 90, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[2], 180, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[3], 45, 0.01);
        }

        [Test]
        public void GetSheepsMaximumEyeMovoment_TenSheep_ReturnMaxEyeMovoment()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 10;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {1, 0},
                {0, 0},
                {1, 1},
                {10, 0},
                {1, -1},
                {6, 2},
                {4, 3},
                {8, 2},
                {6, 0},
                {13, 8}
            };

            // Act
            double[] maxAngleOfSheeps = threeSheepWizard.GetSheepsMaximumEyeMovoment();

            // Assert
            Assert.AreEqual(maxAngleOfSheeps[0], 180, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[1], 90, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[2], 168.690, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[3], 116.892, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[4], 128.659, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[5], 179.999, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[6], 175.364, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[7], 174.805, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[8], 180, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[9], 40.389, 0.01);
        }

        [Test]
        public void GetSheepsMaximumEyeMovoment_FourSheep_SameEyeMovoment()
        {
            // Arrange
            Wizard threeSheepWizard = new Wizard();
            threeSheepWizard.NumberOfSheep = 4;
            threeSheepWizard.SheepCoordinates = new int[,]
            {
                {0, 0},
                {0, 2},
                {2, 2},
                {2, 0}
            };

            // Act
            double[] maxAngleOfSheeps = threeSheepWizard.GetSheepsMaximumEyeMovoment();

            // Assert
            Assert.AreEqual(maxAngleOfSheeps[0], 90, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[1], 90, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[2], 90, 0.01);
            Assert.AreEqual(maxAngleOfSheeps[3], 90, 0.01);
        }
    }
}