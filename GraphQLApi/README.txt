Based on https://www.red-gate.com/simple-talk/dotnet/net-development/getting-started-with-graphql-in-asp-net/

Sample Queries:

```
query GetBlogData($id: Int!) {
  author(id: $id) {
    id
    name
  }
  posts(id: $id) {
    author {
      bio
    }
    categories
    comments {
      description
      commenter
    }
  }
  socials(id: $id) {
    nickName
    type
  }
}
```

Sample Query Variables:

```
{
    "id":1
}
```

- http://localhost:51373/api/authors/1
- http://localhost:51373/api/authors/1/posts
- http://localhost:51373/api/authors/1/socials
