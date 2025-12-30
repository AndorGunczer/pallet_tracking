Install Postgres:
    brew install postgresql
Start the service:
    brew services start postgresql
Create a local database user:
    createuser -s postgres
Connect:
    psql postgres

psql -h localhost -U postgres -d postgres