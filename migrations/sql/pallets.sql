CREATE TABLE pallets (
  id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
  pallet_code text NOT NULL UNIQUE,
  created_at timestamptz NOT NULL DEFAULT now(),
  meta jsonb
);
