CREATE TABLE alerts (
  id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
  pallet_id uuid REFERENCES pallets(id),
  alert_type text NOT NULL, -- e.g. 'stuck','wrong_route','missing_scan'
  details jsonb,
  severity int NOT NULL DEFAULT 1,
  acknowledged boolean NOT NULL DEFAULT false,
  created_at timestamptz NOT NULL DEFAULT now()
);
CREATE INDEX idx_alerts_pallet ON alerts(pallet_id);
