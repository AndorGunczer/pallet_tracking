CREATE TABLE pallet_locations (
  pallet_id uuid PRIMARY KEY REFERENCES pallets(id),
  location_id text NOT NULL,
  last_seen timestamptz NOT NULL,
  scanner_id text,
  meta jsonb
);
