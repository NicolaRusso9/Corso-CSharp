namespace CorsoCSharp
{
    class _37_RangeAndIndex
    {
        public void IndexTest()
        {
            Index i1 = new (value: 3);                  // count from the start
            Index i2 = 3;                               // implicit int conversion operator

            Index i3 = new (value: 5, fromEnd: true);   //  from 5 to the end
            Index i4 = ^5;                              //  from 5 to the end
        }

        public void RangeTest()
        {
            Range r1 = new (start: new Index(3), end: new Index(5));
            Range r2 = new (start: 3, end: 5);                          // using implicit int conversion
            Range r3 = 3..5;                                            // from 3 to 5 - >C# 8  syntax
            Range r4 = Range.StartAt(3);                                // start from 3 to the end
            Range r5 = Range.EndAt(3);                                  // from start to 3

            Range r6 = 5..;                                             // from 5 to last index
            Range r7 = ..3;                                             // from first index to 3

        }
    }
}
