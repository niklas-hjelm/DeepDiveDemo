using API.Domain.Happenings;
using API.Infrastructure.MongoDbUtils;
using MongoDB.Driver;

namespace API.Infrastructure.Happenings;

public class HappeningRepository(MongoConfig config)
	: MongoService<Happening>(config, "Happenings"), IHappeningRepository
{
	public async Task<Happening?> GetByIdAsync(Guid id)
	{
		return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Happening>?> GetMultipleAsync(int start, int count)
	{
		return await Collection.Find(_ => true).Skip(start).Limit(count).ToListAsync();
	}

	public async Task<Happening?> AddAsync(Happening entity)
	{
		await Collection.InsertOneAsync(entity);
		return entity;
	}

	public async Task<Happening?> UpdateAsync(Happening entity)
	{
		await Collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		return entity;
	}

	public async Task DeleteAsync(Guid id)
	{
		await Collection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<IEnumerable<Happening>?> GetMultiple(int start, int count)
	{
		return await Collection.Find(_ => true).Skip(start).Limit(count).ToListAsync();
	}

	public async Task<Happening?> AddSessionAsync(Guid happeningId, Session session)
	{
		var happening = await GetByIdAsync(happeningId);
		if (happening is null)
		{
			throw new InvalidOperationException("Happening not found");
		}
		happening.Sessions.Add(session);
		await UpdateAsync(happening);
		return happening;
	}

	public async Task<Happening?> RemoveSessionAsync(Guid happeningId, Guid sessionId)
	{
		var happening = await GetByIdAsync(happeningId);
		if (happening is null)
		{
			throw new InvalidOperationException("Happening not found");
		}
		var session = happening.Sessions.FirstOrDefault(x => (x as Session).Id == sessionId);
		if (session is null)
		{
			throw new InvalidOperationException("Session not found");
		}
		happening.Sessions.Remove(session);
		await UpdateAsync(happening);
		return happening;
	}

	public async Task<Happening?> AddAttendeeAsync(Guid happeningId, Guid sessionId, Attendee attendee)
	{
		var happening = await GetByIdAsync(happeningId);
		if (happening is null)
		{
			throw new InvalidOperationException("Happening not found");
		}
		var session = happening.Sessions.FirstOrDefault(x => (x as Session).Id == sessionId);
		if (session is null)
		{
			throw new InvalidOperationException("Session not found");
		}
		session.Attendees.Add(attendee);
		await UpdateAsync(happening);
		return happening;
	}

	public async Task<Happening?> RemoveAttendeeAsync(Guid happeningId, Guid sessionId, Guid attendeeId)
	{
		var happening = await GetByIdAsync(happeningId);
		if (happening is null)
		{
			throw new InvalidOperationException("Happening not found");
		}
		var session = happening.Sessions.FirstOrDefault(x => (x as Session).Id == sessionId);
		if (session is null)
		{
			throw new InvalidOperationException("Session not found");
		}
		var attendee = session.Attendees.FirstOrDefault(x => (x as Attendee).UserId == attendeeId.ToString());
		if (attendee is null)
		{
			throw new InvalidOperationException("Attendee not found");
		}
		session.Attendees.Remove(attendee);
		await UpdateAsync(happening);
		return happening;
	}

	public async Task<Happening?> UpdateSessionAsync(Guid happeningId, Guid sessionId, Session session)
	{
		var happening = await GetByIdAsync(happeningId);
		if (happening is null)
		{
			throw new InvalidOperationException("Happening not found");
		}
		var existingSession = happening.Sessions.FirstOrDefault(x => (x as Session).Id == sessionId);
		if (existingSession is null)
		{
			throw new InvalidOperationException("Session not found");
		}
		existingSession.Title = session.Title;
		existingSession.Description = session.Description;
		existingSession.StartDate = session.StartDate;
		existingSession.EndDate = session.EndDate;
		existingSession.Organizer = session.Organizer;
		existingSession.ImageUrl = session.ImageUrl;
		await UpdateAsync(happening);
		return happening;
	}
}