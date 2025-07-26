using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

class SharePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException("shape1 must be not null", nameof(shape1));
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException("shape2 must be not null", nameof(shape2));
        }

        return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
    }
}