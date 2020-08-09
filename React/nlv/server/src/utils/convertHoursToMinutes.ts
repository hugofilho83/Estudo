export default function convetHoursToMinutes(time: string) {
  const [hours, minutus] = time.split(":").map(Number);
  const timeInMinutes = hours * 60 + minutus;

  return timeInMinutes;
}
