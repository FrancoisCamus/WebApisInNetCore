Based on:
- https://fullstackmark.com/post/17/building-a-graphql-api-with-aspnet-core-2-and-entity-framework-core
- https://www.red-gate.com/simple-talk/dotnet/net-development/getting-started-with-graphql-in-asp-net/

Sample Queries:

```
query GetAuthors {
  authors {
    id
    name
    bio
  }
}

query GetAuthor($id: Int!) {
  author(id: $id) {
    id
    name
    posts {
      title
      comments {
        commenter
      }
    }
    socials {
      nickName
    }
  }
}

{
    "id":1
}

```

- Query with Directive
```
query GetAuthor($id: Int!, $withPosts: Boolean!) {
  author(id: $id) {
    id
    name 
    posts @include(if: $withPosts) {
      title
      comments {
        commenter
      }
    }
    socials {
      nickName
    }
  }
}

{
  "id": 1,
  "withPosts": true
}
```

Mutation:

```
mutation ($author: AuthorInput!) {
  createAuthor(author: $author) {
    id
    name
    bio
  }
}

{
  "author": {
    "id": 4,
    "name": "franky",
    "bio": "some developer"
  }
}

```

POST Request:

```
Content-Type: application/json

{ "query":"query GetAuthors { authors { id name bio posts { date comments { commenter } } socials { type } } }", "variables":null, "operationName":"GetAuthors" }

```

- http://localhost:51373/api/authors/1
- http://localhost:51373/api/authors/1/posts
- http://localhost:51373/api/authors/1/socials
