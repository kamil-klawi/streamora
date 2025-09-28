# Api reference

This document provides a full list of REST API endpoints available in the **Streamora** platform.

## Authentication and Authorization

| Method   | Endpoint                | Notes                       | Who   | Status   |
|----------|-------------------------|-----------------------------|-------|----------|
| **POST** | `/auth/register`        | Register a new user         | User  | Core     |
| **POST** | `/auth/login`           | Log in to the platform      | User  | Core     |
| **POST** | `/auth/logout`          | Log out from the platform   | User  | Core     |
| **POST** | `/auth/refresh-token`   | Get a new access token      | User  | Core     |
| **POST** | `/auth/password/forgot` | Request a password reset    | User  | Core     |
| **POST** | `/auth/password/reset`  | Reset password with a token | User  | Core     |
| **POST** | `/auth/2fa/enable`      | Enable 2FA                  | User  | Optional |
| **POST** | `/auth/2fa/verify`      | Verify 2FA Code             | User  | Optional |
| **POST** | `/auth/2fa/disable`     | Disable 2FA                 | User  | Optional |
| **GET**  | `/auth/status`          | Check token status          | User  | Core     |

## Users

| Method     | Endpoint               | Notes                       | Who           | Status   |
|------------|------------------------|-----------------------------|---------------|----------|
| **GET**    | `/users/me`            | Get current user info       | User          | Core     |
| **PATCH**  | `/users/me`            | Update current user info    | User          | Core     |
| **DELETE** | `/users/me`            | Delete current user account | User          | Core     |
| **GET**    | `/users/{userId}`      | Get another user’s profile  | User          | Core     |
| **GET**    | `/users`               | Get list of all users       | User          | Core     |
| **PATCH**  | `/users/{userId}/ban`  | Ban a user                  | Admin, Editor | Optional |
| **PATCH**  | `/users/{userId}/role` | Change user role            | Admin         | Optional |

## Movies

| Method      | Endpoint                              | Notes                          | Who           | Status   |
|-------------|---------------------------------------|--------------------------------|---------------|----------|
| **GET**     | `/movies`                             | Get list of movies             | User          | Core     |
| **GET**     | `/movies/{movieId}`                   | Get movie details              | User          | Core     |
| **POST**    | `/movies`                             | Add a new movie                | Admin, Editor | Core     |
| **PATCH**   | `/movies/{movieId}`                   | Update movie details           | Admin, Editor | Core     |
| **DELETE**  | `/movies/{movieId}`                   | Delete a movie                 | Admin, Editor | Core     |
| **GET**     | `/movies/{movieId}/cast`              | Get movie cast list            | User          | Core     |
| **POST**    | `/movies/{movieId}/cast`              | Add an actor to cast           | Admin, Editor | Core     |
| **DELETE**  | `/movies/{movieId}/cast/{actorId}`    | Delete an actor from cast      | Admin, Editor | Core     |
| **PATCH**   | `/movies/{movieId}/cast/{actorId}`    | Update an actor role           | Admin, Editor | Core     |
| **DELETE**  | `/movies/{movieId}/crew/{crewId}`     | Delete a crew member from crew | Admin, Editor | Core     |
| **PATCH**   | `/movies/{movieId}/crew/{crewId}`     | Update a crew member role      | Admin, Editor | Core     |
| **POST**    | `/movies/{movieId}/crew`              | Add a crew member to crew      | Admin, Editor | Core     |
| **GET**     | `/movies/{movieId}/crew`              | Get movie crew list            | User          | Core     |
| **GET**     | `/movies/popular`                     | Get popular movies             | User          | Optional |
| **GET**     | `/movies/latest`                      | Get latest movies              | User          | Optional |
| **GET**     | `/movies/top-rated`                   | Get top-rated movies           | User          | Optional |

## Actors

| Method     | Endpoint            | Notes                | Who           | Status   |
|------------|---------------------|----------------------|---------------|----------|
| **GET**    | `/actors`           | Get list of actors   | User          | Core     |
| **POST**   | `/actors`           | Create a new actor   | Admin, Editor | Core     |
| **GET**    | `/actors/{actorId}` | Get actor details    | User          | Core     |
| **PATCH**  | `/actors/{actorId}` | Update actor details | Admin, Editor | Core     |
| **DELETE** | `/actors/{actorId}` | Delete an actor      | Admin, Editor | Core     |

## Crew

| Method     | Endpoint         | Notes                      | Who           | Status   |
|------------|------------------|----------------------------|---------------|----------|
| **GET**    | `/crew`          | Get list of crew members   | User          | Core     |
| **POST**   | `/crew`          | Create a new crew member   | Admin, Editor | Core     |
| **GET**    | `/crew/{crewId}` | Get crew member details    | User          | Core     |
| **PATCH**  | `/crew/{crewId}` | Update crew member details | Admin, Editor | Core     |
| **DELETE** | `/crew/{crewId}` | Delete a crew member       | Admin, Editor | Core     |

## Reviews

| Method     | Endpoint                             | Notes                            | Who  | Status   |
|------------|--------------------------------------|----------------------------------|------|----------|
| **GET**    | `/reviews`                           | Get list of your own reviews     | User | Optional |
| **GET**    | `/reviews/{userId}`                  | Get list of another user reviews | User | Optional |
| **GET**    | `/reviews/movies/{movieId}`          | Get movie reviews                | User | Optional |
| **POST**   | `/reviews/movies/{movieId}`          | Add a review to movie            | User | Optional |
| **PUT**    | `/reviews/review/{reviewId}`         | Edit a review                    | User | Optional |
| **DELETE** | `/reviews/review/{reviewId}`         | Delete a review                  | User | Optional |
| **POST**   | `/reviews/review/{reviewId}/comment` | Add a comment to review          | User | Optional |
| **DELETE** | `/reviews/review/{reviewId}/comment` | Delete a comment from review     | User | Optional |
| **POST**   | `/reviews/review/{reviewId}/like`    | Add a like                       | User | Optional |
| **DELETE** | `/reviews/review/{reviewId}/like`    | Delete a like                    | User | Optional |

## Ratings

| Method     | Endpoint              | Notes                 | Who  | Status   |
|------------|-----------------------|-----------------------|------|----------|
| **POST**   | `/ratings/{movieId}`  | Add a rating to movie | User | Optional |
| **GET**    | `/ratings/{movieId}`  | Get movie ratings     | User | Optional |
| **PUT**    | `/ratings/{ratingId}` | Edit a rating         | User | Optional |
| **DELETE** | `/ratings/{ratingId}` | Delete a rating       | User | Optional |

## Genres

| Method     | Endpoint            | Notes              | Who           | Status   |
|------------|---------------------|--------------------|---------------|----------|
| **GET**    | `/genres`           | Get list of genres | User          | Core     |
| **POST**   | `/genres`           | Add a new genre    | Admin, Editor | Core     |
| **PATCH**  | `/genres/{genreId}` | Update a genre     | Admin, Editor | Core     |
| **DELETE** | `/genres/{genreId}` | Delete a genre     | Admin, Editor | Core     |

## Watchlist

| Method     | Endpoint               | Notes                              | Who  | Status   |
|------------|------------------------|------------------------------------|------|----------|
| **GET**    | `/watchlist`           | Get your own watchlist             | User | Optional |
| **GET**    | `/watchlist/{userId}`  | Get list of another user watchlist | User | Optional |
| **POST**   | `/watchlist/{movieId}` | Add to watchlist                   | User | Optional |
| **DELETE** | `/watchlist/{movieId}` | Delete from watchlist              | User | Optional |
