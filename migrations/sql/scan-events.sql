CREATE TABLE scan_events (
  id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
  pallet_id uuid REFERENCES pallets(id) ON DELETE CASCADE,
  scanner_id text NOT NULL,
  location_id text NOT NULL,
  event_time timestamptz NOT NULL,
  payload jsonb,
  created_at timestamptz NOT NULL DEFAULT now()
);
CREATE INDEX idx_scan_events_pallet ON scan_events(pallet_id);
CREATE INDEX idx_scan_events_event_time ON scan_events(event_time);
