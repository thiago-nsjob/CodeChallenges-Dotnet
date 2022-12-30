namespace OrderlyQueue;

public class SolutionTest
{
    public static TheoryData<string, int, string> OrderlyData = new()
    {
        { "cba", 1, "acb" },
        {"baaca",3,"aaabc"},
        {"gxvz",4,"gvxz"}
    };

    public static TheoryData<char, char,bool> IsGreaterData = new()
    {
        { 'a', 'b',false },
        {'B','C',false},
        {'G','z',false},
        {'t','b',true}
    };
    
    [Theory()]
    [MemberData(nameof(OrderlyData))]
    public void Solution_ShouldBe_Expected(string s, int k,string expectedResult)
    {
    
        //Arange
        var solution = new Solution();
        
        //Act
        var result = solution.OrderlyQueue(s, k);
        
        //Assert
        result.Should().Be(expectedResult);
    }
    
    [Theory()]
    [MemberData(nameof(IsGreaterData))]
    public void IsGreater_ShouldReturnTrue_WhenLeftIsLarger(char left, char right,bool expectedResult)
    {
    
        //Arange
        var solution = new Solution();
        
        //Act
        var result = solution.IsGrater(left, right);
        
        //Assert
        result.Should().Be(expectedResult);
    }
    
  
}