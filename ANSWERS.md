# Sprint 2 — Reponses

## Exercice 1 — Cartographie

### 1.1 Classes et interfaces publiques

- BillingService
- BookingService
- EmailSender
- HousekeepingScheduler
- FlexibleCancellationPolicy
- ModerateCancellationPolicy
- StrictCancellationPolicy
- NonRefundableCancellationPolicy
- StandardCleaningPolicy
- VipCleaningPolicy
- InMemoryReservationStore
- InMemoryRoomStore
- InvoiceGenerator
- StandardPricingStrategy
- SuitePricingStrategy
- FamilyPricingStrategy
- RoomAssigner
- SmsSender
- IReservationRepository
- IConfirmationSender
- ICleaningNotifier
- ICancellationPolicy
- IRoomRepository
- PricingStrategyFactory
- TaxCalculator
- IPricingStrategy
- Reservation
- Room
- Invoice
- InvoiceLine
- CleaningTask
- RoomType

### 1.2 Graphe de dependances

![Schéma](imgs/Capture%20d’écran%202026-04-13%20à%2011.31.42.png)

### 1.3 Clusters identifies

- Cluster 1 : Réservation
  - Justification : Ces classes changent ensemble pour des raisons liées aux règles d'accueil (ex: politique d'annulation modifiée, nouvelle règle d'attribution des chambres, changement du délai de confirmation). Elles partagent la responsabilité d'accepter et de valider la venue d'un client. Selon le principe CCP, elles forment une unité logique métier indépendante du nettoyage ou de la comptabilité.
- Cluster 2 : Comptabilité
  - Justification : Ce groupe est dédié aux aspects financiers. Si la loi modifie le taux de TVA ou si la direction décide d'une nouvelle stratégie de prix pour les suites, seules ces classes seront impactées en même temps (CCP). Elles n'ont pas besoin de connaître les règles d'annulation préalables ou les plannings de ménage.
- Cluster 3 : Entretien
  - Justification : Ces classes partagent la responsabilité de l'entretien de l'hôtel. Si la fréquence de ménage passe de "tous les 3 jours" à "tous les 2 jours", le changement sera confiné à ce cluster (CCP). Ce groupe a une forte cohésion interne et ne se soucie ni des prix payés ni des annulations.

---

## Exercice 2 — Decoupage

### Modules crees

| Module | Justification |
|-------|---------------|
| ... | ... |

### Justification par principe

- **CCP** : (expliquez pourquoi vous avez regroupe certaines classes)
- **CRP** : (expliquez pourquoi vous avez separe certaines classes)
- **REP** : (expliquez la coherence de chaque module)

---

## Exercice 3 — Test de la modification

### Scenario A — Politique de menage

- Fichiers modifies : ...
- Modules impactes : ...
- Principe en jeu : ...

### Scenario B — Taux de TVA

- Fichiers modifies : ...
- Modules impactes : ...

### Scenario C — Push notification

- Fichiers crees : ...
- Fichiers modifies : ...
- Modules metier impactes : ...
- Principe en jeu : ...

### Comparaison avec le code de depart

(Paragraphe d'analyse)
