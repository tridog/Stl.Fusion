// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ArrangeConstructorOrDestructorBody
using Cysharp.Text;

namespace Stl.Interception;

[DataContract]
public record ArgumentList
{
    public static ArgumentList Empty { get; } = new();

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public virtual int Length => 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList New()
        => Empty;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0> New<T0>(T0 item0)
        => new (item0);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1> New<T0, T1>(T0 item0, T1 item1)
        => new (item0, item1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2> New<T0, T1, T2>(T0 item0, T1 item1, T2 item2)
        => new (item0, item1, item2);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3> New<T0, T1, T2, T3>(T0 item0, T1 item1, T2 item2, T3 item3)
        => new (item0, item1, item2, item3);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4> New<T0, T1, T2, T3, T4>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4)
        => new (item0, item1, item2, item3, item4);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4, T5> New<T0, T1, T2, T3, T4, T5>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        => new (item0, item1, item2, item3, item4, item5);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4, T5, T6> New<T0, T1, T2, T3, T4, T5, T6>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        => new (item0, item1, item2, item3, item4, item5, item6);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7> New<T0, T1, T2, T3, T4, T5, T6, T7>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        => new (item0, item1, item2, item3, item4, item5, item6, item7);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8> New<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        => new (item0, item1, item2, item3, item4, item5, item6, item7, item8);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> New<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 item0, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9)
        => new (item0, item1, item2, item3, item4, item5, item6, item7, item8, item9);

    public override string ToString() => "()";
    public virtual object?[] ToArray() => Array.Empty<object?>();
    public virtual object?[] ToArray(int skipIndex) => Array.Empty<object?>();

    public virtual T Get<T>(int index)
        => throw new ArgumentOutOfRangeException(nameof(index));
    public virtual object? GetUntyped(int index)
        => throw new ArgumentOutOfRangeException(nameof(index));
    // Virtual non-generic method for frequent operation
    public virtual CancellationToken GetCancellationToken(int index)
        => throw new ArgumentOutOfRangeException(nameof(index));

    public virtual void Set<T>(int index, T value)
         => throw new ArgumentOutOfRangeException(nameof(index));
    public virtual void SetUntyped(int index, object? value)
         => throw new ArgumentOutOfRangeException(nameof(index));
    // Virtual non-generic method for frequent operation
    public virtual void SetCancellationToken(int index, CancellationToken item)
         => throw new ArgumentOutOfRangeException(nameof(index));

    public virtual ArgumentList Insert<T>(int index, T item)
        => index == 0
            ? New(item)
            : throw new ArgumentOutOfRangeException(nameof(index));

    // Virtual non-generic method for frequent operation
    public virtual ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index == 0
            ? New(item)
            : throw new ArgumentOutOfRangeException(nameof(index));

    public virtual ArgumentList Remove(int index)
        => throw new ArgumentOutOfRangeException(nameof(index));

    public virtual bool Equals(ArgumentList? other, int skipIndex)
        => other?.GetType() == typeof(ArgumentList);
    public virtual int GetHashCode(int skipIndex)
        => 1;

    public virtual bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
        => other?.GetType() == typeof(ArgumentList);
    public virtual int GetHashCode(Delegate?[] equalsDelegates)
        => 1;
}

[DataContract]
public sealed record ArgumentList<T0>(
    T0 Item0
) : ArgumentList
{
    private T0 _item0 = Item0;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 1;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex == 0
            ? Array.Empty<object?>()
            : throw new ArgumentOutOfRangeException(nameof(skipIndex));

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0),
            1 => New(Item0, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0),
            1 => New(Item0, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0> vOther)
            return false;

        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 1)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0> vOther)
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 1)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1>(
    T0 Item0,
    T1 Item1
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 2;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1 },
            1 => new object?[] { Item0 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1),
            1 => New(Item0, item, Item1),
            2 => New(Item0, Item1, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1),
            1 => New(Item0, item, Item1),
            2 => New(Item0, Item1, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1),
            1 => New(Item0),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1> vOther)
            return false;

        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 2)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1> vOther)
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 2)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2>(
    T0 Item0,
    T1 Item1,
    T2 Item2
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 3;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2 },
            1 => new object?[] { Item0, Item2 },
            2 => new object?[] { Item0, Item1 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2),
            1 => New(Item0, item, Item1, Item2),
            2 => New(Item0, Item1, item, Item2),
            3 => New(Item0, Item1, Item2, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2),
            1 => New(Item0, item, Item1, Item2),
            2 => New(Item0, Item1, item, Item2),
            3 => New(Item0, Item1, Item2, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2),
            1 => New(Item0, Item2),
            2 => New(Item0, Item1),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2> vOther)
            return false;

        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 3)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2> vOther)
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 3)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 4;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3 },
            1 => new object?[] { Item0, Item2, Item3 },
            2 => new object?[] { Item0, Item1, Item3 },
            3 => new object?[] { Item0, Item1, Item2 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3),
            1 => New(Item0, item, Item1, Item2, Item3),
            2 => New(Item0, Item1, item, Item2, Item3),
            3 => New(Item0, Item1, Item2, item, Item3),
            4 => New(Item0, Item1, Item2, Item3, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3),
            1 => New(Item0, item, Item1, Item2, Item3),
            2 => New(Item0, Item1, item, Item2, Item3),
            3 => New(Item0, Item1, Item2, item, Item3),
            4 => New(Item0, Item1, Item2, Item3, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3),
            1 => New(Item0, Item2, Item3),
            2 => New(Item0, Item1, Item3),
            3 => New(Item0, Item1, Item2),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3> vOther)
            return false;

        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 4)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3> vOther)
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 4)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 5;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4 },
            1 => new object?[] { Item0, Item2, Item3, Item4 },
            2 => new object?[] { Item0, Item1, Item3, Item4 },
            3 => new object?[] { Item0, Item1, Item2, Item4 },
            4 => new object?[] { Item0, Item1, Item2, Item3 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4),
            1 => New(Item0, item, Item1, Item2, Item3, Item4),
            2 => New(Item0, Item1, item, Item2, Item3, Item4),
            3 => New(Item0, Item1, Item2, item, Item3, Item4),
            4 => New(Item0, Item1, Item2, Item3, item, Item4),
            5 => New(Item0, Item1, Item2, Item3, Item4, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4),
            1 => New(Item0, item, Item1, Item2, Item3, Item4),
            2 => New(Item0, Item1, item, Item2, Item3, Item4),
            3 => New(Item0, Item1, Item2, item, Item3, Item4),
            4 => New(Item0, Item1, Item2, Item3, item, Item4),
            5 => New(Item0, Item1, Item2, Item3, Item4, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4),
            1 => New(Item0, Item2, Item3, Item4),
            2 => New(Item0, Item1, Item3, Item4),
            3 => New(Item0, Item1, Item2, Item4),
            4 => New(Item0, Item1, Item2, Item3),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4> vOther)
            return false;

        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 5)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4> vOther)
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 5)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4, T5>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4,
    T5 Item5
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;
    private T5 _item5 = Item5;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }
    [DataMember(Order = 5)] public T5 Item5 { get => _item5; init => _item5 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 6;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4, Item5 },
            1 => new object?[] { Item0, Item2, Item3, Item4, Item5 },
            2 => new object?[] { Item0, Item1, Item3, Item4, Item5 },
            3 => new object?[] { Item0, Item1, Item2, Item4, Item5 },
            4 => new object?[] { Item0, Item1, Item2, Item3, Item5 },
            5 => new object?[] { Item0, Item1, Item2, Item3, Item4 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            5 => Item5 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            5 => Item5,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            5 => Item5 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = item is T5 item5 ? item5 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4, Item5),
            1 => New(Item0, Item2, Item3, Item4, Item5),
            2 => New(Item0, Item1, Item3, Item4, Item5),
            3 => New(Item0, Item1, Item2, Item4, Item5),
            4 => New(Item0, Item1, Item2, Item3, Item5),
            5 => New(Item0, Item1, Item2, Item3, Item4),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4, T5>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T5>.Default.Equals(Item5, other.Item5))
            return false;
        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            hashCode = 397*hashCode + EqualityComparer<T5>.Default.GetHashCode(Item5!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5> vOther)
            return false;

        if (skipIndex != 5 && !EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;
        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            hashCode = 397*hashCode + (skipIndex == 5 ? 0 : EqualityComparer<T5>.Default.GetHashCode(Item5!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 6)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5> vOther)
            return false;

        if (equalsDelegates[5] is Func<T5, T5, bool> func5) {
            if (!func5.Invoke(Item5, vOther.Item5))
                return false;
        }
        else if (!EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 6)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            if (getHashCodeDelegates[5] is Func<T5, int> func5)
                hashCode = (hashCode * 397) + func5.Invoke(Item5!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T5>.Default.GetHashCode(Item5!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4, T5, T6>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4,
    T5 Item5,
    T6 Item6
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;
    private T5 _item5 = Item5;
    private T6 _item6 = Item6;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }
    [DataMember(Order = 5)] public T5 Item5 { get => _item5; init => _item5 = value; }
    [DataMember(Order = 6)] public T6 Item6 { get => _item6; init => _item6 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 7;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4, Item5, Item6 },
            1 => new object?[] { Item0, Item2, Item3, Item4, Item5, Item6 },
            2 => new object?[] { Item0, Item1, Item3, Item4, Item5, Item6 },
            3 => new object?[] { Item0, Item1, Item2, Item4, Item5, Item6 },
            4 => new object?[] { Item0, Item1, Item2, Item3, Item5, Item6 },
            5 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item6 },
            6 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            5 => Item5 is T value ? value : default!,
            6 => Item6 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            5 => Item5,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            6 => Item6,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            5 => Item5 is CancellationToken value ? value : default!,
            6 => Item6 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = item is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = item is T6 item6 ? item6 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4, Item5, Item6),
            1 => New(Item0, Item2, Item3, Item4, Item5, Item6),
            2 => New(Item0, Item1, Item3, Item4, Item5, Item6),
            3 => New(Item0, Item1, Item2, Item4, Item5, Item6),
            4 => New(Item0, Item1, Item2, Item3, Item5, Item6),
            5 => New(Item0, Item1, Item2, Item3, Item4, Item6),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4, T5, T6>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T6>.Default.Equals(Item6, other.Item6))
            return false;
        if (!EqualityComparer<T5>.Default.Equals(Item5, other.Item5))
            return false;
        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            hashCode = 397*hashCode + EqualityComparer<T5>.Default.GetHashCode(Item5!);
            hashCode = 397*hashCode + EqualityComparer<T6>.Default.GetHashCode(Item6!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6> vOther)
            return false;

        if (skipIndex != 6 && !EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;
        if (skipIndex != 5 && !EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;
        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            hashCode = 397*hashCode + (skipIndex == 5 ? 0 : EqualityComparer<T5>.Default.GetHashCode(Item5!));
            hashCode = 397*hashCode + (skipIndex == 6 ? 0 : EqualityComparer<T6>.Default.GetHashCode(Item6!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 7)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6> vOther)
            return false;

        if (equalsDelegates[6] is Func<T6, T6, bool> func6) {
            if (!func6.Invoke(Item6, vOther.Item6))
                return false;
        }
        else if (!EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;

        if (equalsDelegates[5] is Func<T5, T5, bool> func5) {
            if (!func5.Invoke(Item5, vOther.Item5))
                return false;
        }
        else if (!EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 7)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            if (getHashCodeDelegates[5] is Func<T5, int> func5)
                hashCode = (hashCode * 397) + func5.Invoke(Item5!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T5>.Default.GetHashCode(Item5!);

            if (getHashCodeDelegates[6] is Func<T6, int> func6)
                hashCode = (hashCode * 397) + func6.Invoke(Item6!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T6>.Default.GetHashCode(Item6!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4,
    T5 Item5,
    T6 Item6,
    T7 Item7
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;
    private T5 _item5 = Item5;
    private T6 _item6 = Item6;
    private T7 _item7 = Item7;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }
    [DataMember(Order = 5)] public T5 Item5 { get => _item5; init => _item5 = value; }
    [DataMember(Order = 6)] public T6 Item6 { get => _item6; init => _item6 = value; }
    [DataMember(Order = 7)] public T7 Item7 { get => _item7; init => _item7 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 8;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4, Item5, Item6, Item7 },
            1 => new object?[] { Item0, Item2, Item3, Item4, Item5, Item6, Item7 },
            2 => new object?[] { Item0, Item1, Item3, Item4, Item5, Item6, Item7 },
            3 => new object?[] { Item0, Item1, Item2, Item4, Item5, Item6, Item7 },
            4 => new object?[] { Item0, Item1, Item2, Item3, Item5, Item6, Item7 },
            5 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item6, Item7 },
            6 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item7 },
            7 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            5 => Item5 is T value ? value : default!,
            6 => Item6 is T value ? value : default!,
            7 => Item7 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            5 => Item5,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            6 => Item6,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            7 => Item7,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            5 => Item5 is CancellationToken value ? value : default!,
            6 => Item6 is CancellationToken value ? value : default!,
            7 => Item7 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = item is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = item is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = item is T7 item7 ? item7 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6, Item7),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6, Item7),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6, Item7),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6, Item7),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6, Item7),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item, Item7),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6, Item7),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6, Item7),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6, Item7),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6, Item7),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6, Item7),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item, Item7),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            1 => New(Item0, Item2, Item3, Item4, Item5, Item6, Item7),
            2 => New(Item0, Item1, Item3, Item4, Item5, Item6, Item7),
            3 => New(Item0, Item1, Item2, Item4, Item5, Item6, Item7),
            4 => New(Item0, Item1, Item2, Item3, Item5, Item6, Item7),
            5 => New(Item0, Item1, Item2, Item3, Item4, Item6, Item7),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item7),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T7>.Default.Equals(Item7, other.Item7))
            return false;
        if (!EqualityComparer<T6>.Default.Equals(Item6, other.Item6))
            return false;
        if (!EqualityComparer<T5>.Default.Equals(Item5, other.Item5))
            return false;
        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            hashCode = 397*hashCode + EqualityComparer<T5>.Default.GetHashCode(Item5!);
            hashCode = 397*hashCode + EqualityComparer<T6>.Default.GetHashCode(Item6!);
            hashCode = 397*hashCode + EqualityComparer<T7>.Default.GetHashCode(Item7!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7> vOther)
            return false;

        if (skipIndex != 7 && !EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;
        if (skipIndex != 6 && !EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;
        if (skipIndex != 5 && !EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;
        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            hashCode = 397*hashCode + (skipIndex == 5 ? 0 : EqualityComparer<T5>.Default.GetHashCode(Item5!));
            hashCode = 397*hashCode + (skipIndex == 6 ? 0 : EqualityComparer<T6>.Default.GetHashCode(Item6!));
            hashCode = 397*hashCode + (skipIndex == 7 ? 0 : EqualityComparer<T7>.Default.GetHashCode(Item7!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 8)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7> vOther)
            return false;

        if (equalsDelegates[7] is Func<T7, T7, bool> func7) {
            if (!func7.Invoke(Item7, vOther.Item7))
                return false;
        }
        else if (!EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;

        if (equalsDelegates[6] is Func<T6, T6, bool> func6) {
            if (!func6.Invoke(Item6, vOther.Item6))
                return false;
        }
        else if (!EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;

        if (equalsDelegates[5] is Func<T5, T5, bool> func5) {
            if (!func5.Invoke(Item5, vOther.Item5))
                return false;
        }
        else if (!EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 8)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            if (getHashCodeDelegates[5] is Func<T5, int> func5)
                hashCode = (hashCode * 397) + func5.Invoke(Item5!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T5>.Default.GetHashCode(Item5!);

            if (getHashCodeDelegates[6] is Func<T6, int> func6)
                hashCode = (hashCode * 397) + func6.Invoke(Item6!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T6>.Default.GetHashCode(Item6!);

            if (getHashCodeDelegates[7] is Func<T7, int> func7)
                hashCode = (hashCode * 397) + func7.Invoke(Item7!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T7>.Default.GetHashCode(Item7!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4,
    T5 Item5,
    T6 Item6,
    T7 Item7,
    T8 Item8
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;
    private T5 _item5 = Item5;
    private T6 _item6 = Item6;
    private T7 _item7 = Item7;
    private T8 _item8 = Item8;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }
    [DataMember(Order = 5)] public T5 Item5 { get => _item5; init => _item5 = value; }
    [DataMember(Order = 6)] public T6 Item6 { get => _item6; init => _item6 = value; }
    [DataMember(Order = 7)] public T7 Item7 { get => _item7; init => _item7 = value; }
    [DataMember(Order = 8)] public T8 Item8 { get => _item8; init => _item8 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 9;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(", ");
        sb.Append(Item8);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8 },
            1 => new object?[] { Item0, Item2, Item3, Item4, Item5, Item6, Item7, Item8 },
            2 => new object?[] { Item0, Item1, Item3, Item4, Item5, Item6, Item7, Item8 },
            3 => new object?[] { Item0, Item1, Item2, Item4, Item5, Item6, Item7, Item8 },
            4 => new object?[] { Item0, Item1, Item2, Item3, Item5, Item6, Item7, Item8 },
            5 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item6, Item7, Item8 },
            6 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item7, Item8 },
            7 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item8 },
            8 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            5 => Item5 is T value ? value : default!,
            6 => Item6 is T value ? value : default!,
            7 => Item7 is T value ? value : default!,
            8 => Item8 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            5 => Item5,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            6 => Item6,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            7 => Item7,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            8 => Item8,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            5 => Item5 is CancellationToken value ? value : default!,
            6 => Item6 is CancellationToken value ? value : default!,
            7 => Item7 is CancellationToken value ? value : default!,
            8 => Item8 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = value is T8 item8 ? item8 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = value is T8 item8 ? item8 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = item is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = item is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = item is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = item is T8 item8 ? item8 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6, Item7, Item8),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6, Item7, Item8),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6, Item7, Item8),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6, Item7, Item8),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item, Item7, Item8),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, item, Item8),
            9 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => index switch {
            0 => New(item, Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            1 => New(Item0, item, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            2 => New(Item0, Item1, item, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            3 => New(Item0, Item1, Item2, item, Item3, Item4, Item5, Item6, Item7, Item8),
            4 => New(Item0, Item1, Item2, Item3, item, Item4, Item5, Item6, Item7, Item8),
            5 => New(Item0, Item1, Item2, Item3, Item4, item, Item5, Item6, Item7, Item8),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, item, Item6, Item7, Item8),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, item, Item7, Item8),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, item, Item8),
            9 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, item),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            1 => New(Item0, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            2 => New(Item0, Item1, Item3, Item4, Item5, Item6, Item7, Item8),
            3 => New(Item0, Item1, Item2, Item4, Item5, Item6, Item7, Item8),
            4 => New(Item0, Item1, Item2, Item3, Item5, Item6, Item7, Item8),
            5 => New(Item0, Item1, Item2, Item3, Item4, Item6, Item7, Item8),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item7, Item8),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item8),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T8>.Default.Equals(Item8, other.Item8))
            return false;
        if (!EqualityComparer<T7>.Default.Equals(Item7, other.Item7))
            return false;
        if (!EqualityComparer<T6>.Default.Equals(Item6, other.Item6))
            return false;
        if (!EqualityComparer<T5>.Default.Equals(Item5, other.Item5))
            return false;
        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            hashCode = 397*hashCode + EqualityComparer<T5>.Default.GetHashCode(Item5!);
            hashCode = 397*hashCode + EqualityComparer<T6>.Default.GetHashCode(Item6!);
            hashCode = 397*hashCode + EqualityComparer<T7>.Default.GetHashCode(Item7!);
            hashCode = 397*hashCode + EqualityComparer<T8>.Default.GetHashCode(Item8!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8> vOther)
            return false;

        if (skipIndex != 8 && !EqualityComparer<T8>.Default.Equals(Item8, vOther.Item8))
            return false;
        if (skipIndex != 7 && !EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;
        if (skipIndex != 6 && !EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;
        if (skipIndex != 5 && !EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;
        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            hashCode = 397*hashCode + (skipIndex == 5 ? 0 : EqualityComparer<T5>.Default.GetHashCode(Item5!));
            hashCode = 397*hashCode + (skipIndex == 6 ? 0 : EqualityComparer<T6>.Default.GetHashCode(Item6!));
            hashCode = 397*hashCode + (skipIndex == 7 ? 0 : EqualityComparer<T7>.Default.GetHashCode(Item7!));
            hashCode = 397*hashCode + (skipIndex == 8 ? 0 : EqualityComparer<T8>.Default.GetHashCode(Item8!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 9)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8> vOther)
            return false;

        if (equalsDelegates[8] is Func<T8, T8, bool> func8) {
            if (!func8.Invoke(Item8, vOther.Item8))
                return false;
        }
        else if (!EqualityComparer<T8>.Default.Equals(Item8, vOther.Item8))
            return false;

        if (equalsDelegates[7] is Func<T7, T7, bool> func7) {
            if (!func7.Invoke(Item7, vOther.Item7))
                return false;
        }
        else if (!EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;

        if (equalsDelegates[6] is Func<T6, T6, bool> func6) {
            if (!func6.Invoke(Item6, vOther.Item6))
                return false;
        }
        else if (!EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;

        if (equalsDelegates[5] is Func<T5, T5, bool> func5) {
            if (!func5.Invoke(Item5, vOther.Item5))
                return false;
        }
        else if (!EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 9)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            if (getHashCodeDelegates[5] is Func<T5, int> func5)
                hashCode = (hashCode * 397) + func5.Invoke(Item5!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T5>.Default.GetHashCode(Item5!);

            if (getHashCodeDelegates[6] is Func<T6, int> func6)
                hashCode = (hashCode * 397) + func6.Invoke(Item6!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T6>.Default.GetHashCode(Item6!);

            if (getHashCodeDelegates[7] is Func<T7, int> func7)
                hashCode = (hashCode * 397) + func7.Invoke(Item7!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T7>.Default.GetHashCode(Item7!);

            if (getHashCodeDelegates[8] is Func<T8, int> func8)
                hashCode = (hashCode * 397) + func8.Invoke(Item8!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T8>.Default.GetHashCode(Item8!);

            return hashCode;
        }
    }
}

[DataContract]
public sealed record ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
    T0 Item0,
    T1 Item1,
    T2 Item2,
    T3 Item3,
    T4 Item4,
    T5 Item5,
    T6 Item6,
    T7 Item7,
    T8 Item8,
    T9 Item9
) : ArgumentList
{
    private T0 _item0 = Item0;
    private T1 _item1 = Item1;
    private T2 _item2 = Item2;
    private T3 _item3 = Item3;
    private T4 _item4 = Item4;
    private T5 _item5 = Item5;
    private T6 _item6 = Item6;
    private T7 _item7 = Item7;
    private T8 _item8 = Item8;
    private T9 _item9 = Item9;

    [DataMember(Order = 0)] public T0 Item0 { get => _item0; init => _item0 = value; }
    [DataMember(Order = 1)] public T1 Item1 { get => _item1; init => _item1 = value; }
    [DataMember(Order = 2)] public T2 Item2 { get => _item2; init => _item2 = value; }
    [DataMember(Order = 3)] public T3 Item3 { get => _item3; init => _item3 = value; }
    [DataMember(Order = 4)] public T4 Item4 { get => _item4; init => _item4 = value; }
    [DataMember(Order = 5)] public T5 Item5 { get => _item5; init => _item5 = value; }
    [DataMember(Order = 6)] public T6 Item6 { get => _item6; init => _item6 = value; }
    [DataMember(Order = 7)] public T7 Item7 { get => _item7; init => _item7 = value; }
    [DataMember(Order = 8)] public T8 Item8 { get => _item8; init => _item8 = value; }
    [DataMember(Order = 9)] public T9 Item9 { get => _item9; init => _item9 = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int Length => 10;

    // ToString & ToArray

    public override string ToString()
    {
        using var sb = ZString.CreateStringBuilder();
        sb.Append('(');
        sb.Append(Item0);
        sb.Append(", ");
        sb.Append(Item1);
        sb.Append(", ");
        sb.Append(Item2);
        sb.Append(", ");
        sb.Append(Item3);
        sb.Append(", ");
        sb.Append(Item4);
        sb.Append(", ");
        sb.Append(Item5);
        sb.Append(", ");
        sb.Append(Item6);
        sb.Append(", ");
        sb.Append(Item7);
        sb.Append(", ");
        sb.Append(Item8);
        sb.Append(", ");
        sb.Append(Item9);
        sb.Append(')');
        return sb.ToString();
    }

    public override object?[] ToArray()
        => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9 };

    public override object?[] ToArray(int skipIndex)
        => skipIndex switch {
            0 => new object?[] { Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9 },
            1 => new object?[] { Item0, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9 },
            2 => new object?[] { Item0, Item1, Item3, Item4, Item5, Item6, Item7, Item8, Item9 },
            3 => new object?[] { Item0, Item1, Item2, Item4, Item5, Item6, Item7, Item8, Item9 },
            4 => new object?[] { Item0, Item1, Item2, Item3, Item5, Item6, Item7, Item8, Item9 },
            5 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item6, Item7, Item8, Item9 },
            6 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item7, Item8, Item9 },
            7 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item8, Item9 },
            8 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item9 },
            9 => new object?[] { Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8 },
            _ => throw new ArgumentOutOfRangeException(nameof(skipIndex))
        };

    // Get

    public override T Get<T>(int index)
        => index switch {
            0 => Item0 is T value ? value : default!,
            1 => Item1 is T value ? value : default!,
            2 => Item2 is T value ? value : default!,
            3 => Item3 is T value ? value : default!,
            4 => Item4 is T value ? value : default!,
            5 => Item5 is T value ? value : default!,
            6 => Item6 is T value ? value : default!,
            7 => Item7 is T value ? value : default!,
            8 => Item8 is T value ? value : default!,
            9 => Item9 is T value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override object? GetUntyped(int index)
        => index switch {
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            0 => Item0,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            1 => Item1,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            2 => Item2,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            3 => Item3,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            4 => Item4,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            5 => Item5,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            6 => Item6,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            7 => Item7,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            8 => Item8,
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            9 => Item9,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    public override CancellationToken GetCancellationToken(int index)
        => index switch {
            0 => Item0 is CancellationToken value ? value : default!,
            1 => Item1 is CancellationToken value ? value : default!,
            2 => Item2 is CancellationToken value ? value : default!,
            3 => Item3 is CancellationToken value ? value : default!,
            4 => Item4 is CancellationToken value ? value : default!,
            5 => Item5 is CancellationToken value ? value : default!,
            6 => Item6 is CancellationToken value ? value : default!,
            7 => Item7 is CancellationToken value ? value : default!,
            8 => Item8 is CancellationToken value ? value : default!,
            9 => Item9 is CancellationToken value ? value : default!,
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Set

    public override void Set<T>(int index, T value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = value is T8 item8 ? item8 : default!;
            break;
        case 9:
            _item9 = value is T9 item9 ? item9 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetUntyped(int index, object? value)
    {
        switch (index) {
        case 0:
            _item0 = value is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = value is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = value is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = value is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = value is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = value is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = value is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = value is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = value is T8 item8 ? item8 : default!;
            break;
        case 9:
            _item9 = value is T9 item9 ? item9 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public override void SetCancellationToken(int index, CancellationToken item)
    {
        switch (index) {
        case 0:
            _item0 = item is T0 item0 ? item0 : default!;
            break;
        case 1:
            _item1 = item is T1 item1 ? item1 : default!;
            break;
        case 2:
            _item2 = item is T2 item2 ? item2 : default!;
            break;
        case 3:
            _item3 = item is T3 item3 ? item3 : default!;
            break;
        case 4:
            _item4 = item is T4 item4 ? item4 : default!;
            break;
        case 5:
            _item5 = item is T5 item5 ? item5 : default!;
            break;
        case 6:
            _item6 = item is T6 item6 ? item6 : default!;
            break;
        case 7:
            _item7 = item is T7 item7 ? item7 : default!;
            break;
        case 8:
            _item8 = item is T8 item8 ? item8 : default!;
            break;
        case 9:
            _item9 = item is T9 item9 ? item9 : default!;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    // Insert

    public override ArgumentList Insert<T>(int index, T item)
        => throw new ArgumentOutOfRangeException(nameof(index));

    public override ArgumentList InsertCancellationToken(int index, CancellationToken item)
        => throw new ArgumentOutOfRangeException(nameof(index));

    // Remove

    public override ArgumentList Remove(int index)
        => index switch {
            0 => New(Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9),
            1 => New(Item0, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9),
            2 => New(Item0, Item1, Item3, Item4, Item5, Item6, Item7, Item8, Item9),
            3 => New(Item0, Item1, Item2, Item4, Item5, Item6, Item7, Item8, Item9),
            4 => New(Item0, Item1, Item2, Item3, Item5, Item6, Item7, Item8, Item9),
            5 => New(Item0, Item1, Item2, Item3, Item4, Item6, Item7, Item8, Item9),
            6 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item7, Item8, Item9),
            7 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item8, Item9),
            8 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item9),
            9 => New(Item0, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };

    // Equality

    public bool Equals(ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>? other)
    {
        if (other == null)
            return false;

        if (!EqualityComparer<T9>.Default.Equals(Item9, other.Item9))
            return false;
        if (!EqualityComparer<T8>.Default.Equals(Item8, other.Item8))
            return false;
        if (!EqualityComparer<T7>.Default.Equals(Item7, other.Item7))
            return false;
        if (!EqualityComparer<T6>.Default.Equals(Item6, other.Item6))
            return false;
        if (!EqualityComparer<T5>.Default.Equals(Item5, other.Item5))
            return false;
        if (!EqualityComparer<T4>.Default.Equals(Item4, other.Item4))
            return false;
        if (!EqualityComparer<T3>.Default.Equals(Item3, other.Item3))
            return false;
        if (!EqualityComparer<T2>.Default.Equals(Item2, other.Item2))
            return false;
        if (!EqualityComparer<T1>.Default.Equals(Item1, other.Item1))
            return false;
        if (!EqualityComparer<T0>.Default.Equals(Item0, other.Item0))
            return false;
        return true;
    }

    public override int GetHashCode()
    {
        unchecked {
            var hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + EqualityComparer<T1>.Default.GetHashCode(Item1!);
            hashCode = 397*hashCode + EqualityComparer<T2>.Default.GetHashCode(Item2!);
            hashCode = 397*hashCode + EqualityComparer<T3>.Default.GetHashCode(Item3!);
            hashCode = 397*hashCode + EqualityComparer<T4>.Default.GetHashCode(Item4!);
            hashCode = 397*hashCode + EqualityComparer<T5>.Default.GetHashCode(Item5!);
            hashCode = 397*hashCode + EqualityComparer<T6>.Default.GetHashCode(Item6!);
            hashCode = 397*hashCode + EqualityComparer<T7>.Default.GetHashCode(Item7!);
            hashCode = 397*hashCode + EqualityComparer<T8>.Default.GetHashCode(Item8!);
            hashCode = 397*hashCode + EqualityComparer<T9>.Default.GetHashCode(Item9!);
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, int skipIndex)
    {
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> vOther)
            return false;

        if (skipIndex != 9 && !EqualityComparer<T9>.Default.Equals(Item9, vOther.Item9))
            return false;
        if (skipIndex != 8 && !EqualityComparer<T8>.Default.Equals(Item8, vOther.Item8))
            return false;
        if (skipIndex != 7 && !EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;
        if (skipIndex != 6 && !EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;
        if (skipIndex != 5 && !EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;
        if (skipIndex != 4 && !EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;
        if (skipIndex != 3 && !EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;
        if (skipIndex != 2 && !EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;
        if (skipIndex != 1 && !EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;
        if (skipIndex != 0 && !EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;
        return true;
    }

    public override int GetHashCode(int skipIndex)
    {
        unchecked {
            var hashCode = skipIndex == 0 ? 0 : EqualityComparer<T0>.Default.GetHashCode(Item0!);
            hashCode = 397*hashCode + (skipIndex == 1 ? 0 : EqualityComparer<T1>.Default.GetHashCode(Item1!));
            hashCode = 397*hashCode + (skipIndex == 2 ? 0 : EqualityComparer<T2>.Default.GetHashCode(Item2!));
            hashCode = 397*hashCode + (skipIndex == 3 ? 0 : EqualityComparer<T3>.Default.GetHashCode(Item3!));
            hashCode = 397*hashCode + (skipIndex == 4 ? 0 : EqualityComparer<T4>.Default.GetHashCode(Item4!));
            hashCode = 397*hashCode + (skipIndex == 5 ? 0 : EqualityComparer<T5>.Default.GetHashCode(Item5!));
            hashCode = 397*hashCode + (skipIndex == 6 ? 0 : EqualityComparer<T6>.Default.GetHashCode(Item6!));
            hashCode = 397*hashCode + (skipIndex == 7 ? 0 : EqualityComparer<T7>.Default.GetHashCode(Item7!));
            hashCode = 397*hashCode + (skipIndex == 8 ? 0 : EqualityComparer<T8>.Default.GetHashCode(Item8!));
            hashCode = 397*hashCode + (skipIndex == 9 ? 0 : EqualityComparer<T9>.Default.GetHashCode(Item9!));
            return hashCode;
        }
    }

    public override bool Equals(ArgumentList? other, Delegate?[] equalsDelegates)
    {
        if (equalsDelegates.Length < 10)
            throw new ArgumentOutOfRangeException(nameof(equalsDelegates));
        if (other is not ArgumentList<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> vOther)
            return false;

        if (equalsDelegates[9] is Func<T9, T9, bool> func9) {
            if (!func9.Invoke(Item9, vOther.Item9))
                return false;
        }
        else if (!EqualityComparer<T9>.Default.Equals(Item9, vOther.Item9))
            return false;

        if (equalsDelegates[8] is Func<T8, T8, bool> func8) {
            if (!func8.Invoke(Item8, vOther.Item8))
                return false;
        }
        else if (!EqualityComparer<T8>.Default.Equals(Item8, vOther.Item8))
            return false;

        if (equalsDelegates[7] is Func<T7, T7, bool> func7) {
            if (!func7.Invoke(Item7, vOther.Item7))
                return false;
        }
        else if (!EqualityComparer<T7>.Default.Equals(Item7, vOther.Item7))
            return false;

        if (equalsDelegates[6] is Func<T6, T6, bool> func6) {
            if (!func6.Invoke(Item6, vOther.Item6))
                return false;
        }
        else if (!EqualityComparer<T6>.Default.Equals(Item6, vOther.Item6))
            return false;

        if (equalsDelegates[5] is Func<T5, T5, bool> func5) {
            if (!func5.Invoke(Item5, vOther.Item5))
                return false;
        }
        else if (!EqualityComparer<T5>.Default.Equals(Item5, vOther.Item5))
            return false;

        if (equalsDelegates[4] is Func<T4, T4, bool> func4) {
            if (!func4.Invoke(Item4, vOther.Item4))
                return false;
        }
        else if (!EqualityComparer<T4>.Default.Equals(Item4, vOther.Item4))
            return false;

        if (equalsDelegates[3] is Func<T3, T3, bool> func3) {
            if (!func3.Invoke(Item3, vOther.Item3))
                return false;
        }
        else if (!EqualityComparer<T3>.Default.Equals(Item3, vOther.Item3))
            return false;

        if (equalsDelegates[2] is Func<T2, T2, bool> func2) {
            if (!func2.Invoke(Item2, vOther.Item2))
                return false;
        }
        else if (!EqualityComparer<T2>.Default.Equals(Item2, vOther.Item2))
            return false;

        if (equalsDelegates[1] is Func<T1, T1, bool> func1) {
            if (!func1.Invoke(Item1, vOther.Item1))
                return false;
        }
        else if (!EqualityComparer<T1>.Default.Equals(Item1, vOther.Item1))
            return false;

        if (equalsDelegates[0] is Func<T0, T0, bool> func0) {
            if (!func0.Invoke(Item0, vOther.Item0))
                return false;
        }
        else if (!EqualityComparer<T0>.Default.Equals(Item0, vOther.Item0))
            return false;

        return true;
    }

    public override int GetHashCode(Delegate?[] getHashCodeDelegates)
    {
        if (getHashCodeDelegates.Length < 10)
            throw new ArgumentOutOfRangeException(nameof(getHashCodeDelegates));
        unchecked {
            int hashCode;
            if (getHashCodeDelegates[0] is Func<T0, int> func0)
                hashCode = func0.Invoke(Item0!);
            else
                hashCode = EqualityComparer<T0>.Default.GetHashCode(Item0!);

            if (getHashCodeDelegates[1] is Func<T1, int> func1)
                hashCode = (hashCode * 397) + func1.Invoke(Item1!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T1>.Default.GetHashCode(Item1!);

            if (getHashCodeDelegates[2] is Func<T2, int> func2)
                hashCode = (hashCode * 397) + func2.Invoke(Item2!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T2>.Default.GetHashCode(Item2!);

            if (getHashCodeDelegates[3] is Func<T3, int> func3)
                hashCode = (hashCode * 397) + func3.Invoke(Item3!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T3>.Default.GetHashCode(Item3!);

            if (getHashCodeDelegates[4] is Func<T4, int> func4)
                hashCode = (hashCode * 397) + func4.Invoke(Item4!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T4>.Default.GetHashCode(Item4!);

            if (getHashCodeDelegates[5] is Func<T5, int> func5)
                hashCode = (hashCode * 397) + func5.Invoke(Item5!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T5>.Default.GetHashCode(Item5!);

            if (getHashCodeDelegates[6] is Func<T6, int> func6)
                hashCode = (hashCode * 397) + func6.Invoke(Item6!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T6>.Default.GetHashCode(Item6!);

            if (getHashCodeDelegates[7] is Func<T7, int> func7)
                hashCode = (hashCode * 397) + func7.Invoke(Item7!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T7>.Default.GetHashCode(Item7!);

            if (getHashCodeDelegates[8] is Func<T8, int> func8)
                hashCode = (hashCode * 397) + func8.Invoke(Item8!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T8>.Default.GetHashCode(Item8!);

            if (getHashCodeDelegates[9] is Func<T9, int> func9)
                hashCode = (hashCode * 397) + func9.Invoke(Item9!);
            else
                hashCode = (hashCode * 397) + EqualityComparer<T9>.Default.GetHashCode(Item9!);

            return hashCode;
        }
    }
}

