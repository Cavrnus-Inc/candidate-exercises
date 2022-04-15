export default class Rng {
    public static next(min: number, max: number) {
        return Math.floor(Math.random() * (max - min) + min);
    }
}
