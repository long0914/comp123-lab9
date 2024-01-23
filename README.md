You will learn about enums, static members and default arguments.

## Enums

An enum is a user-define type like a class. However, all the members are
constants with implied values. It provides an efficient way of defining
a set of named integral constants such as the days of the week or months
of the year or even the set of pre-defined colors.

It supports a more robust programming style e.g. If you have a method
that expects a month as an argument of type to a string, you will have
do lots of defensive programming, instead define an enum type that has
the 12 months. During development, the compiler will do the necessary
checks for the require type hence you will do less programming.

## Static members

The static decorator when used on a member indicates that member belongs
to the type rather than an object. You will access that member using the
type rather than an object reference. Static methods or properties may
only access other static members. The only instance member that can be
accessed is the constructor.

You can recognize an instance member by the absence of the static
modifier. Instance methods are able to access other instance members as
well as class members.

# The TimeFormat Enum

Sometimes you don’t even care about the underlining values as in this
case or, (Maritial status: Single, Married, Widowed etc.), (Sale status:
Confirmed, Shipped, Paid etc.)

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>TimeFormat</strong></p>
<p>Enum</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Values</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>Mil</p>
<p>Hour12</p>
<p>Hour24</p>
</blockquote></td>
</tr>
</tbody>
</table>

You may define/code this type in the Time.cs file, but it should be
external to the Time class.

# The Time Class

**<u>UML Class Diagram</u>**

\$ 🡪 static

\- 🡪 private

\+ 🡪 public

\# 🡪 protected

### Code the Time class below:

This class comprise of six members: a field, two properties and two
methods and a constructor a SetTimeFormat() and a ToString() method. All
the fields are private and all the methods are public

<table>
<colgroup>
<col style="width: 100%" />
</colgroup>
<thead>
<tr class="header">
<th><p><strong>Time</strong></p>
<p>Class</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><strong>Fields</strong></td>
</tr>
<tr class="even">
<td></td>
</tr>
<tr class="odd">
<td><strong>Properties</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>-$ TIME_FORMAT = <mark>TimeFormat.Hour12</mark> :
<strong><mark>TimeFormat</mark></strong></p>
<p>+ «setter absent» Hour : <strong><mark>int</mark></strong></p>
<p>+ «setter absent» Minute : <strong><mark>int</mark></strong></p>
</blockquote></td>
</tr>
<tr class="odd">
<td><strong>Methods</strong></td>
</tr>
<tr class="even">
<td><blockquote>
<p>+ «constructor» Time(hour = 0 : <strong><mark>int</mark></strong>,
minute = 0: <strong><mark>int</mark></strong>)</p>
<p>+ ToString() : <strong><mark>string</mark></strong></p>
<p>$+ SetFormat(timeFormat : <strong><mark>TimeFormat</mark></strong>) :
<strong><mark>void</mark></strong></p>
</blockquote></td>
</tr>
</tbody>
</table>

#### Description of class members

A class member that is decorated with the
**<span class="mark">static</span>** keyword implies that only one copy
of this member exists and it is shared by all objects of the class. i.e.
If it is changed then all object will see the new value immediately.

A class method can only access other class member
(fields/properties/methods)

##### Fields:

There are no fields for this class.

##### Properties:

**TIME_FORMAT** – this class variable is of type
<span class="mark">TimeFormat</span> and it represents the intended
format of the ToString() method. This field has private accessibility
and it initializes to <span class="mark">TimeFormat.Hour12</span> at
declaration.

**Hour** – this is an integer representing the hour value this object.
This property has public read access and the setter is missing.

**Minute** – this is an integer representing the minute value this
object. This property has public read access and the setter is missing.

##### Constructor:

**<span class="mark">public</span> Time(int hours = 0, int minutes =
0)** – This is a public constructor that takes two integer arguments
with default values of **0**. If checks if the first argument is between
0 and 24 it assigns it to the Hour property otherwise a value of 0 is
assign to the hour property. Similarly the second argument is check if
it is between 0 and 60 then it is assigned to the Minute property
otherwise a value of 0 is assigned to the Minute property.

##### Methods:

**<span class="mark">public override string</span> ToString()** – This
public method overrides the ToString of the object class. It does not
take any argument and returns a string representation of the object. The
return value will depend on the field TIME_FORMAT value of the class. So
it is a good plan if you use a switch statement to handle the three
possibilities. Your switch statement should check the value of the
TIME_FORMAT field.

If you have a Time object with the hours value as **18** and the minutes
value as **5** then the print out of the object will be

A **switch** statement is probably the simplest way to implement this
functionality

“1805” if TIME_FORMAT is set to <span class="mark">TimeFormat.MIL. Use
the d2 format specifier to get the leading zero.</span>

“18:05” if TIME_FORMAT is set to
<span class="mark">TimeFormat.HOUR2</span>4<span class="mark">. Again,
use the d2 format specifier to get the leading zero.</span>

“6:05 PM” if TIME_FORMAT is set to <span class="mark">TimeFormat.HOUR12.
Again, use the d2 format specifier to get the leading zero.</span>

**<span class="mark">public static void</span>
SetTimeFormat(**<span class="mark">TimeFormat</span> **time_format)** –
This a class method that is public. It takes a single
<span class="mark">TimeFormat</span> argument and assigns it to the
static TIME_FORMAT field.

This method must be static because it needs to access a static field.

### Test Harness

Insert the following code statements in your Program.cs file:

<span class="mark">//create a list to store the objects</span>

<span class="mark">List\<Time\> times = new List\<Time\>()</span>

<span class="mark">{</span>

<span class="mark">new Time(9, 35),</span>

<span class="mark">new Time(18, 5),</span>

<span class="mark">new Time(20, 500),</span>

<span class="mark">new Time(10),</span>

<span class="mark">new Time()</span>

<span class="mark">};</span>

<span class="mark">//display all the objects</span>

<span class="mark">TimeFormat format = TimeFormat.Hour12;</span>

<span class="mark">Console.WriteLine(\$"\n\nTime format is
{format}");</span>

<span class="mark">foreach (Time t in times)</span>

<span class="mark">{</span>

<span class="mark">Console.WriteLine(t);</span>

<span class="mark">}</span>

<span class="mark">//change the format of the output</span>

<span class="mark">format = TimeFormat.Mil;</span>

<span class="mark">Console.WriteLine(\$"\n\nSetting time format to
{format}");</span>

<span class="mark">//SetFormat(TimeFormat) is a class member, so you
need the type to access it</span>

<span class="mark">Time.SetFormat(format);</span>

<span class="mark">//again display all the objects</span>

<span class="mark">foreach (Time t in times)</span>

<span class="mark">{</span>

<span class="mark">Console.WriteLine(t);</span>

<span class="mark">}</span>

<span class="mark">//change the format of the output</span>

<span class="mark">format = TimeFormat.Hour24;</span>

<span class="mark">Console.WriteLine(\$"\n\nSetting time format to
{format}");</span>

<span class="mark">//SetFormat(TimeFormat) is a class member, so you
need the type to access it</span>

<span class="mark">Time.SetFormat(format);</span>

<span class="mark">foreach (Time t in times)</span>

<span class="mark">{</span>

<span class="mark">Console.WriteLine(t);</span>

<span class="mark">}</span>

Your output will look like below:

Time format is Hour12

9:35 AM

6:05 PM

8:00 PM

10:00 AM

0:00 AM

Setting time format to Mil

0935

1805

2000

1000

0000

Setting time format to Hour24

09:35

18:05

20:00

10:00

00:00
