using System;
using System.Text;
using Xunit;
using Project1;

namespace Project1.Tests;
public class UnitTest1
{
    #region Record
    [Fact]
    public void RecordToString1()
    {
        // Arrange
        Record testRecord = new Record("test", 1, 100, 1);
        var sb = new StringBuilder();
        sb.AppendLine("Name: test");
        sb.AppendLine("\tDays Played: 1");
        sb.AppendLine("\tStarting Balance: $100");
        sb.AppendLine("\tPerformance: Gained $1");
        string test = sb.ToString();

        // Act
        string result = testRecord.ToString();
        
        // Assert
        Assert.Equal(test, result);
    }
    
    [Fact]
    public void RecordToString2()
    {
        // Arrange
        Record testRecord = new Record("test", 1, 100, -1);
        var sb = new StringBuilder();
        sb.AppendLine("Name: test");
        sb.AppendLine("\tDays Played: 1");
        sb.AppendLine("\tStarting Balance: $100");
        sb.AppendLine("\tPerformance: Lost   $1");
        string test = sb.ToString();

        // Act
        string result = testRecord.ToString();
        
        // Assert
        Assert.Equal(test, result);
    }
    
    [Fact]
    public void RecordToString3()
    {
        // Arrange
        Record testRecord = new Record("test", 1, 100, 0);
        var sb = new StringBuilder();
        sb.AppendLine("Name: test");
        sb.AppendLine("\tDays Played: 1");
        sb.AppendLine("\tStarting Balance: $100");
        sb.AppendLine("\tPerformance: Lost   $0");
        string test = sb.ToString();

        // Act
        string result = testRecord.ToString();
        
        // Assert
        Assert.Equal(test, result);
    }
    #endregion

    #region Data
    [Fact]
    public void GetPrice1()
    {
        // Given
        Data testData = new Data(1);
        testData.OpenPrice[0] = 1;
    
        // When
        int result = testData.GetPrice(1,true);
    
        // Then
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void GetPrice2()
    {
        // Given
        Data testData = new Data(1);
        testData.ClosePrice[0] = 1;
    
        // When
        int result = testData.GetPrice(1,false);
    
        // Then
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void GetPrice3()
    {
        // Given
        Data testData = new Data(1);
    
        // When
        int result = testData.GetPrice(-1,false);
    
        // Then
        Assert.Equal(-1, result);
    }
    
    [Fact]
    public void DataToString1()
    {
        // Given
        Data testData = new Data(1);
        testData.OpenPrice[0] = 1;
        testData.ClosePrice[0] = 1;

        var sb = new StringBuilder();
        sb.Append("Day: 1");
        sb.Append("\tOpening Price: $1");
        sb.AppendLine("\tClosing Price: $1");
        string test = sb.ToString();

        // When
        string result = testData.ToString();
    
        // Then
        Assert.Equal(test, result);
    }
    
    [Fact]
    public void GenerateData1(){
        // Arrange
        Data testData = new Data(1);

        // Act
        testData.GenerateData(0,1);
        
        // Assert
        Assert.Equal(0,testData.OpenPrice[0]);
    }
    
    [Fact]
    public void GenerateData2(){
        // Arrange
        Data testData = new Data(1);

        // Act
        testData.GenerateData(1,0);
        
        // Assert
        Assert.Equal(0,testData.OpenPrice[0]);
    }
    #endregion

    #region Day
    [Fact]
    public void Next1(){
        // Arrange
        Day testDay = new Day(1);

        // Act
        bool test = testDay.Next();

        // Assert
        Assert.Equal(true, test);
    }

    [Fact]
    public void Next2(){
        // Arrange
        Day testDay = new Day(1);
        testDay.isStartOfDay = false;

        // Act
        bool test = testDay.Next();

        // Assert
        Assert.Equal(false, test);
    }

    [Fact]
    public void Set1(){
        // Arrange
        Day testDay = new Day(1);

        // Act
        testDay.Set(1,false);

        // Assert
        Assert.Equal(false, testDay.isStartOfDay);
    }
    
    [Fact]
    public void Set2(){
        // Arrange
        Day testDay = new Day(1);

        // Act
        testDay.Set(2,false);

        // Assert
        Assert.Equal(1, testDay.day);
    }
    #endregion
}