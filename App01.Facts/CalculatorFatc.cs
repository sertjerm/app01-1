using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace App01.Facts {
    public class CalculatorFatc {


        public class AddMethod : IDisposable {

            private Calculator c;
            private readonly ITestOutputHelper _output;

            public AddMethod(ITestOutputHelper output) {
                c = new Calculator();
                _output = output;
            }




            [Theory]
            [InlineData("1", "1", "2")]
            [InlineData("2", "2", "4")]
            // [MemberData("OneDigitInputs", 10)]
            public void OneDigit(string v1, string v2, string expected) {
                //arrange
                // var c = new Calculator();

                //act
                var result = c.Add(v1, v2);

                //assert
                _output.WriteLine($"{v1} + {v2} = {result}");
                Assert.Equal(expected, result);
            }

            public static IEnumerable<Object[]> OneDigitInputs(int count) {
                for (int i = 0; i < count; i++) {
                    yield return new object[] {
            i.ToString() , i.ToString() , i.ToString()
          };
                }
            }


            [Fact]
            public void NegativeValues() {

                //act
                var result = c.Add("-5", "8");

                //assert
                Assert.Equal("3", result);
            }

            [Fact]
            public void EmptyStringOrNull_TreatAsZero() {

                //act
                var result1 = c.Add(null, "9");
                var result2 = c.Add("", "9");
                var result3 = c.Add("9", null);
                var result4 = c.Add("9", "");
                //assert
                Assert.Equal("9", result1);
                Assert.Equal("9", result2);
                Assert.Equal("9", result3);
                Assert.Equal("9", result4);
            }

            [Fact]
            public void TwoDigits() {

                var result = c.Add("11", "22");
                Assert.Equal("3", result);

            }


            [Fact]
            public void OnlyDigitCharacterIsAllowed() {
                var ex = Assert.Throws<ArgumentException>(() => {
                    var result = c.Add("1a", "2b");
                });
                Assert.Equal("value1", ex.ParamName);
            }

            [Fact]
            public void AddTwoDigits() {
                var result = c.Add("11", "25");
                Assert.Equal("36", result);

            }

            //TearDown
            public void Dispose() {
                c = null;
                //throw new NotImplementedException();
            }
        }
    }
}
