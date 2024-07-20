FIRST RUN OF THE SOLUTION:

1. Install Microsoft.EntityFrameworkCore.Tools (8.0.0).
2. Open Package Manager Console.
3. cd into the project directory.
4. Run: dotnet ef database update
5. Run the project and register a new user.


FINAL THOUGHTS ON THE TEST AND THE TASKS:

1. Done.

2. Done.

3. Done.

4. Done.

5. I started it, but decided to move to the backend tasks instead, because it felt like I need to add javascript logic with hiddenfield usage and it felt
too difficult for this short amount of time. I do not have good rpactical experience with frontend stack, so I need more google searching to complete this.

6. Done.

7. Done, except "Add a new option on the details page to order by rank." for that is again, a frontend task and I'd rather focused on the backend parts.

8. Done, however I skipped the "Display the name along side the email address", because the rest of the task's completion was more important. I added caching
to the data retrieval, because Gravatar has rate limit even on registered accounts and set the cache to expire in 1 hour (that is the rate limit time at their end).
This task took the longest, because I had to turn all the static classes into injectable non-static ones and generally quite a few files were changed. I, however,
added one new unit test to cover the provider to ensure the cache is properly used.

9. Did not have time to start.

10. Did not have time to start.

Generally speaking, 5 hours were almost enough to finish the backend part. The whole solution is hard-to-read and navigate, class names were not reflecting the
intention of the content of the class, and the whole solution needs some more refactoring. I know it was part of the test, but it felt like the whole solution was
created by a junior.
I also have not worked with EF for quite some time, so I had to look up basically everything related to migration.
I did not have time to add tests (not just unit, but also integration) to the service, the proxy and other parts. That alone would take many, many hours!
Exception handling is a bit "simplified". I just simply did not have enough time for making everything "production-ready", so I just used one custom exception class,
but even its usage is not 100% correct and the part where the user details are retrieved, but results in error needs to be fine tuned.