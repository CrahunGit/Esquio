
# Roadmap 

## Esquio 1.1  November 2019

- Fine grained fallback service that enable fallbacservice request delegate for all or specific endpoints.
- Add entropy on GraduallRollout to prevent scenarios when the "partitioner value" is the same for different features with the same toggle.
- Add new HeaderValueToggle
- Make our partitioner plugable
- Improve http api with new features.
- Added Typed EventData instead of anonymous type on DiagnosticSource events.
- Enable pagination on UI.
- Enable tag filtering for flags on UI.
- Enable authorization on UI with 3 levels of privileges
    - Read permission ( can read data ).
    - Write permission ( can write on database ).
    - Management permission ( can generate apikeys and add new user permissions. ).

## Esquio 1.0.1 released on 2019, October 2

- Esquio 1.0.1
    - Fixing bug on FromToToggle when use one digit on month, day or hour.

## Esquio 1.0 released on 2019, September 24

- Esquio 1.0
- Esquio.AspNetCore 1.0
- Esquio.ConfigurationStore 1.0
- Esquio.EntityFrameworkStore 1.0
- MVP for Esquio.UI