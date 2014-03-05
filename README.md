TableDataSource
===============

A complete code behind ObjectDataSource in C# with default sorting, paging and ControlState saving.

There are a lot of questions concerning paging and sorting of a gridview: http://stackoverflow.com/search?q=gridview+sorting+paging . Most recommend to use an ObjectDataSource which you need to put on your layout page. Maybe it's because I come from a CakePHP background, but it seemed somehow wrong to put a DataSource onto your layout. What I wanted was a DataSource that you can just let your GridView bind to in the codebehind, all while the DataSource would take care of the sorting, the paging and the caching for you. Without having to c/p code or attach events, or having your code scattered on multiple pages.
