using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

class ShareAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        ArgumentNullException.ThrowIfNull(shape1);

        ArgumentNullException.ThrowIfNull(shape2);

        return shape2.GetArea().CompareTo(shape1.GetArea());
    }
}