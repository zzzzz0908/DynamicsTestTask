# Test task for MS Dynamics CRM Developer course
Implemented Calculate method which calculates finish date, which is calculated as a start date + duration without weekends.

Following scenarios are handled:
- **No weekends** (weekend array is either null or empty)
- **Normal path**: Weekends are excluded
- **Weekend before start / after end**: These weekends are ignored
- **Start date on weekend**: Weekend days before start date are ignored, weekend days from start date to weekend end are handled as simple weekend
- **Zero duration** (daysCount): Correct result is assumed to be start date, regardless whether it is weekend or not (such edge cases shoud be discussed with team and customer)

Negative duration isn't handled (should ArgumentException or ArgumentOutOfRangeException be thrown?)
